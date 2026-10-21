namespace SEIMS.Models
{
    /// <summary>
    /// Storage protocol every stock item must follow (Question 2).
    /// </summary>
    public interface IStorable
    {
        string StorageLocation { get; set; }
        bool RequiresRefrigeration { get; }
        string GetStorageInstructions();
        bool CanBeStoredAt(string location);
    }
}
