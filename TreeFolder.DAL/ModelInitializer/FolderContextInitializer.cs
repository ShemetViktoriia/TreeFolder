using System.Collections.Generic;
using System.Data.Entity;
using TreeFolder.DAL.Model;

namespace TreeFolder.DAL.ModelInitializer
{
    class FolderContextInitializer : DropCreateDatabaseIfModelChanges<FolderContext>
    {
        protected override void Seed(FolderContext context)
        {
            var listFolders = new List<Folder>
            {
                new Folder
                {
                    FolderName = "Creating Digital Images",
                    FolderOrder = 1,
                    NavURL = "Creating Digital Images", 
                    Children = new List<Folder>
                    {
                        new Folder
                        {
                            FolderName = "Resources",
                            FolderOrder = 1,
                            NavURL = "Creating Digital Images/Resources", 
                            Children = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Primary Sources",
                                    FolderOrder = 1,
                                    NavURL = "Creating Digital Images/Resources/Primary Sources" 
                                },
                                new Folder
                                {
                                    FolderName = "Secondary Sources",
                                    FolderOrder = 2,
                                    NavURL = "Creating Digital Images/Resources/Secondary Sources" 
                                }
                            }
                        },
                        new Folder
                        {
                            FolderName = "Evidence",
                            FolderOrder = 2,
                            NavURL = "Creating Digital Images/Evidence" 
                        },
                        new Folder
                        {
                            FolderName = "Graphic Products",
                            FolderOrder = 3,
                            NavURL = "Creating Digital Images/Graphic Products", 
                            Children = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Process",
                                    FolderOrder = 1,
                                    NavURL = "Creating Digital Images/Graphic Products/Process"
                                },
                                new Folder
                                {
                                    FolderName = "Final Product",
                                    FolderOrder = 2,
                                    NavURL = "Creating Digital Images/Graphic Products/Final Product" 
                                }
                            }
                        }
                    }
                }
            };
            context.Folders.AddRange(listFolders);
            context.SaveChanges();
        }
    }
}
