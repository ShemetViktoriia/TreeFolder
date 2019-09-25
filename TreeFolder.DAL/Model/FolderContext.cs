using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using TreeFolder.DAL.Common;
using TreeFolder.DAL.ModelConfiguration;
using TreeFolder.DAL.ModelInitializer;

namespace TreeFolder.DAL.Model
{
    public class FolderContext : DbContext
    {
        static FolderContext()
        {
            Database.SetInitializer(new FolderContextInitializer());
        }

        public FolderContext(): base("DbConnection")
        {

        }

        public virtual DbSet<Folder> Folders { get; set; }

        // Override the OnModelCreating method to add
        // configuration settings
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FolderConfiguration());
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
              .Where(x => x.Entity is IAuditableEntity
                  && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    //TODO later for Web
                    string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }
            return base.SaveChanges();
        }
    }
}