using System.Collections.Generic;

namespace TreeFolder.WebApp.Models
{
    public class FolderViewModel
    {
        public long Id { get; set; }
        public string FolderName { get; set; }
        public string NavURL { get; set; }
        public virtual ICollection<FolderViewModel> Children { get; set; }
    }
}