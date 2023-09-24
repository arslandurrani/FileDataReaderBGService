namespace FileDataReaderBGService.Entities;

public class ELDEvents : BaseEntity
{
    /// <summary>
    /// To check if the data is processed for the sync with other table or not
    /// </summary>
    public bool IsProcessed { get; set; } = false;
}
