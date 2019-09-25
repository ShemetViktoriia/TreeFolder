using System.Collections.Generic;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.BaseRepository;

namespace TreeFolder.Repository.Repositories
{
    public interface IFolderRepository: IBaseRepository<Folder>
    {
        ICollection<Folder> GetChildFolders(Folder node);
    }
}
