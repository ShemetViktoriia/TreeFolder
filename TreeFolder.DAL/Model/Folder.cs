using System.Collections.Generic;
using TreeFolder.DAL.Common;

namespace TreeFolder.DAL.Model
{
    /// <summary>
    /// Keeps folders in database
    /// </summary>
    public class Folder : AuditableEntity<long>
    {
        public string FolderName { get; set; }
        public string NavURL { get; set; }
        public int? FolderOrder { get; set; }
        public long? ParentFolderId { get; set; }
        public virtual Folder ParentFolder { get; set; }
        public virtual ICollection<Folder> Children { get; set; }
    }
}
