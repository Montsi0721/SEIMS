using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SEIMS.Collections;
using SEIMS.Events;
using SEIMS.Models;

namespace SEIMS.Services
{
    public class ImportResult
    {
        public int Imported;
        public int Skipped;
        public List<string> Errors = new List<string>();
    }

    /// <summary>
    /// Data parsing routine wrapped in detailed try / catch / finally blocks (Question 5).
    /// CSV columns: sku,name,category,quantity,minimumLevel,unitPrice,location
    /// </summary>
    public static class CsvImporter
    {
        public static ImportResult Import(string path, InventoryService service, LogHandler log)
        {
            ImportResult result = new ImportResult();      // local variable
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(path);
                string line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (lineNumber == 1 && line.StartsWith("sku", StringComparison.OrdinalIgnoreCase)) continue;

                    try
                    {
                        string[] p = line.Split(',');
                        if (p.Length < 7) throw new FormatException("expected 7 columns but found " + p.Length);

                        string categoryName = InputSanitizer.CleanText(p[2], 60);
                        Category category = service.Categories.FirstOrDefault(
                            c => string.Equals(c.Name, categoryName, StringComparison.OrdinalIgnoreCase));
                        if (category == null) throw new FormatException("unknown category '" + categoryName + "'");

                        InventoryItem item = new InventoryItem(
                            InputSanitizer.CleanText(p[0], 30),
                            InputSanitizer.CleanText(p[1], 100),
                            category.Id,
                            SafeParser.ToInt32Strict(p[3], "Quantity"),
                            SafeParser.ToInt32Strict(p[4], "Minimum level"),
                            SafeParser.ToDecimalStrict(p[5], "Unit price"),
                            InputSanitizer.CleanText(p[6], 100));

                        service.AddItem(item);
                        result.Imported++;
                    }
                    catch (FormatException ex)
                    {
                        result.Skipped++;
                        result.Errors.Add("Line " + lineNumber + ": " + ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        result.Skipped++;
                        result.Errors.Add("Line " + lineNumber + ": " + ex.Message);
                    }
                    catch (DuplicateItemException ex)
                    {
                        result.Skipped++;
                        result.Errors.Add("Line " + lineNumber + ": " + ex.Message);
                    }
                    catch (DbUpdateException ex)
                    {
                        result.Skipped++;
                        SqlException sql = ex.InnerException as SqlException;
                        result.Errors.Add("Line " + lineNumber + ": database rejected the row - " +
                                          (sql != null ? sql.Message : ex.Message));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                result.Errors.Add("File not found: " + path);
            }
            catch (IOException ex)
            {
                result.Errors.Add("Could not read the file: " + ex.Message);
            }
            catch (SqlException ex)
            {
                result.Errors.Add("SQL Server error: " + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Dispose();
                if (log != null)
                    log("CSV import finished: " + result.Imported + " imported, " + result.Skipped + " skipped.");
            }

            return result;
        }
    }
}
