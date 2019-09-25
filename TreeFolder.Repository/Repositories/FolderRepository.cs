using System.Data.Entity;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.BaseRepository;

namespace TreeFolder.Repository.Repositories
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(DbContext context)
            : base(context)
        {

        }

        public Folder GetRootFolder()
        {
            return SingleOrDefault(f => f.ParentFolderId == null);
        }
    }
}
