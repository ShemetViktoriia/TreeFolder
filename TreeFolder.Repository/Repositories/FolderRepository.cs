using System.Collections.Generic;
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

        public ICollection<Folder> GetChildFolders(Folder node)
        {

            throw new System.NotImplementedException();
        }
    }
}
