using System;

namespace FileDataReaderBGService.Entities
{
    public class ELDEventsServer : BaseEntity
    {
        /// <summary>
        /// to have unique Id for for this record
        /// </summary>
        public Guid Unique_Id { get; set; } = Guid.NewGuid();
    }
}
