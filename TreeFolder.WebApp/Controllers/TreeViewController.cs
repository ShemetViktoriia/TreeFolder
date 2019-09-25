using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TreeFolder.Repository.Repositories;
using TreeFolder.WebApp.Extensions;
using TreeFolder.WebApp.Models;

namespace TreeFolder.WebApp.Controllers
{
    public class TreeViewController : Controller
    {
        #region Fields
        private IFolderRepository repo;
        #endregion

        #region Ctors
        public TreeViewController(IFolderRepository folderRepository)
        {
            repo = folderRepository;
        }
        #endregion

        // GET: TreeView
        public ActionResult Index(string path)
        {
            var rootFolderViewModel = new FolderViewModel();
            var rootFolder = repo.GetFolder(path);
            var subFolders = repo.GetSubFolders(rootFolder.Id).ToList();

            rootFolderViewModel = rootFolder.MapToViewModel(subFolders);
            return View(rootFolderViewModel);
        }
    }
}