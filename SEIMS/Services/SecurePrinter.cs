using System.Drawing.Printing;
using SEIMS.Models;

namespace SEIMS.Services
{
    /// <summary>
    /// Secure printing (Question 10): only roles with the Print permission can print, printing always
    /// goes through a preview, a confidential footer is added and every print is audited.
    /// </summary>
    public static class SecurePrinter
    {
        public static void ShowPreview(IWin32Window owner, string title, IList<string> lines, Action<string> audit)
        {
            SecurityService.Demand(Permission.Print);

            int index = 0;
            using (var doc = new PrintDocument())
            {
                doc.DocumentName = title;
                doc.PrinterSettings.Copies = 1;
                doc.PrinterSettings.PrintToFile = false;
                doc.DefaultPageSettings.Margins = new Margins(60, 60, 70, 70);

                doc.BeginPrint += (s, e) => { index = 0; };
                doc.PrintPage += (s, e) =>
                {
                    using (var titleFont = new Font("Consolas", 13, FontStyle.Bold))
                    using (var noteFont = new Font("Segoe UI", 8, FontStyle.Italic))
                    using (var bodyFont = new Font("Consolas", 9))
                    {
                        float x = e.MarginBounds.Left;
                        float y = e.MarginBounds.Top;

                        e.Graphics.DrawString(title, titleFont, Brushes.Black, x, y);
                        y += titleFont.GetHeight(e.Graphics) + 2;

                        string note = "CONFIDENTIAL - printed by " + SecurityService.CurrentUsername +
                                      " (" + SecurityService.CurrentRole + ") on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        e.Graphics.DrawString(note, noteFont, Brushes.DarkRed, x, y);
                        y += noteFont.GetHeight(e.Graphics) + 10;

                        float lineHeight = bodyFont.GetHeight(e.Graphics);
                        while (index < lines.Count && y + lineHeight < e.MarginBounds.Bottom)
                        {
                            e.Graphics.DrawString(InputSanitizer.StripControl(lines[index]), bodyFont, Brushes.Black, x, y);
                            y += lineHeight;
                            index++;
                        }

                        e.HasMorePages = index < lines.Count;
                    }
                };

                using (var preview = new PrintPreviewDialog())
                {
                    preview.Document = doc;
                    preview.Width = 900;
                    preview.Height = 720;
                    preview.StartPosition = FormStartPosition.CenterParent;
                    preview.ShowDialog(owner);
                }
            }

            if (audit != null) audit("Print preview opened: " + title);
        }
    }
}
