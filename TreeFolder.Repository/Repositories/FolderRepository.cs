using System;
using System.Collections.Generic;
using System.Linq;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.BaseRepository;

namespace TreeFolder.Repository.Repositories
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository, IDisposable
    {
        public FolderContext Context { get; set; }
        public FolderRepository(FolderContext context)
            : base(context)
        {

        }

        public Folder GetRootFolder()
        {
            return SingleOrDefault(f => f.ParentFolderId == null);
        }

        public Folder GetFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return GetRootFolder();
            }
            return SingleOrDefault(f => f.NavURL.Equals(path));
        }

        public ICollection<Folder> GetSubFolders(long pid)
        {
            return Find(f => f.ParentFolderId==pid).OrderBy(f=>f.FolderOrder).ToList();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
