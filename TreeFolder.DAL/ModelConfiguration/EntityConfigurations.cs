using System.Data.Entity.ModelConfiguration;
using TreeFolder.DAL.Model;

namespace TreeFolder.DAL.ModelConfiguration
{
    public class FolderConfiguration : EntityTypeConfiguration<Folder>
    {
        public FolderConfiguration()
        {
            this.Property(f => f.FolderName).IsRequired().HasMaxLength(50);
            this.Property(f => f.NavURL).IsRequired();
        }
    }
}
