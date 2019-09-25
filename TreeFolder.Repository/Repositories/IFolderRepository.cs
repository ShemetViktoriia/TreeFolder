using System.Collections.Generic;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.BaseRepository;

namespace TreeFolder.Repository.Repositories
{
    public interface IFolderRepository: IBaseRepository<Folder>
    {
        Folder GetRootFolder();
        Folder GetFolder(string path);
        ICollection<Folder> GetSubFolders(long pid);
    }
}
