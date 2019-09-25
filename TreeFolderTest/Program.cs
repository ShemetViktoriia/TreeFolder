using System;
using TreeFolder.DAL.Model;
using TreeFolder.Repository.Repositories;

namespace TreeFolderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderRepo = new FolderRepository(new FolderContext());
            foreach (var item in folderRepo.GetAll())
            {

            }
            //using (var db = new FolderContext())
            //{
            //    foreach (var folder in db.Folders.Include(f=>f.ChildFolders))
            //    {
            //        Console.WriteLine(folder.FolderName);
            //        foreach (var childFolder in folder.ChildFolders)
            //        {
            //            Console.WriteLine("\t" + childFolder.FolderName);
            //        }
            //    }
            //}
            Console.ReadKey();
        }
    }
}
