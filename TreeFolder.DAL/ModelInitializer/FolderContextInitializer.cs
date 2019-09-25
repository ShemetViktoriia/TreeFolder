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
                    NavURL = "", //TODO
                    Children = new List<Folder>
                    {
                        new Folder
                        {
                            FolderName = "Resources",
                            FolderOrder = 1,
                            NavURL = "", //TODO
                            Children = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Primary Sources",
                                    FolderOrder = 1,
                                    NavURL = "" //TODO
                                },
                                new Folder
                                {
                                    FolderName = "Secondary Sources",
                                    FolderOrder = 2,
                                    NavURL = "" //TODO
                                }
                            }
                        },
                        new Folder
                        {
                            FolderName = "Evidence",
                            FolderOrder = 2,
                            NavURL = "" //TODO
                        },
                        new Folder
                        {
                            FolderName = "Graphic Products",
                            FolderOrder = 3,
                            NavURL = "", //TODO
                            Children = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Process",
                                    FolderOrder = 1,
                                    NavURL = "" //TODO
                                },
                                new Folder
                                {
                                    FolderName = "Final Product",
                                    FolderOrder = 2,
                                    NavURL = "" //TODO
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
