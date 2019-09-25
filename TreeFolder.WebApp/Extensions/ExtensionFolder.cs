using System.Collections.Generic;
using TreeFolder.DAL.Model;
using TreeFolder.WebApp.Models;

namespace TreeFolder.WebApp.Extensions
{
    public static class ExtensionFolder
    {
        public static FolderViewModel MapToViewModel(this Folder folder, List<Folder> subFolders)
        {
            var childrenListViewModel = new List<FolderViewModel>();

            foreach (var child in subFolders)
            {
                childrenListViewModel.Add(new FolderViewModel
                {
                    Id =child.Id,
                    FolderName = child.FolderName,
                    NavURL = child.NavURL
                });
            }

            var folderViewModel = new FolderViewModel()
            {
                Id = folder.Id,
                FolderName = folder.FolderName,
                NavURL = folder.NavURL,
                Children = childrenListViewModel
            };
            return folderViewModel;
        }
    }
}