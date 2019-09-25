using System.Collections.Generic;
using TreeFolder.DAL.Common;

namespace TreeFolder.DAL.Model
{
    /// <summary>
    /// Keeps folders in database
    /// </summary>
    public partial class Folder : AuditableEntity<long>
    {
        public string FolderName { get; set; }
        public string NavURL { get; set; }
        public ICollection<Folder> ChildFolders { get; set; }
    }
}
