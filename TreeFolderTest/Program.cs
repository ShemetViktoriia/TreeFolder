using System;
using System.Linq;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.Repositories;

namespace TreeFolderTest
{
    class Program
    {
        static void PrintDirectoryTree(Folder root, string indent, bool last)
        {
            Console.WriteLine(indent + "+- " + root.FolderName);
            indent += last ? "   " : "|  ";

            var childFolders = root.Children.OrderBy(f=>f.FolderOrder).ToList();
            for (int i = 0; i < childFolders.Count; i++)
            {
                PrintDirectoryTree(childFolders[i], 
                                   indent,
                                   i == childFolders.Count - 1);
            }
        }
        static void Main(string[] args)
        {
            var folderRepo = new FolderRepository(new FolderContext());
            var rootFolder = folderRepo.GetRootFolder();
            PrintDirectoryTree(rootFolder, "", true);

            Console.ReadKey();
        }
    }
}
