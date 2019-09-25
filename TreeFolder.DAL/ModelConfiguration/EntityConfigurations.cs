using System.Data.Entity.ModelConfiguration;
using TreeFolder.DAL.Model;

namespace TreeFolder.DAL.ModelConfiguration
{
    public class FolderConfiguration : EntityTypeConfiguration<Folder>
    {
        public FolderConfiguration()
        {
            this.Property(f => f.FolderName).IsRequired().HasMaxLength(100);
            this.Property(f => f.NavURL).IsRequired();
            this.HasOptional(f => f.ParentFolder)
                            .WithMany(f => f.Children)
                            .HasForeignKey(f => f.ParentFolderId);
        }
    }
}
