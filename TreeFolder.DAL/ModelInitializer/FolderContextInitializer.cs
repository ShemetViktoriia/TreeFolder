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
                    NavURL = "", //TODO
                    ChildFolders = new List<Folder>
                    {
                        new Folder
                        {
                            FolderName = "Resources",
                            NavURL = "", //TODO
                            ChildFolders = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Primary Sources",
                                    NavURL = "", //TODO
                                    ChildFolders = null
                                },
                                new Folder
                                {
                                    FolderName = "Secondary Sources",
                                    NavURL = "", //TODO
                                    ChildFolders = null
                                }
                            }
                        },
                        new Folder
                        {
                            FolderName = "Evidence",
                            NavURL = "", //TODO
                            ChildFolders = null
                        },
                        new Folder
                        {
                            FolderName = "Graphic Products",
                            NavURL = "", //TODO
                            ChildFolders = new List<Folder>
                            {
                                new Folder
                                {
                                    FolderName = "Process",
                                    NavURL = "", //TODO
                                    ChildFolders = null
                                },
                                new Folder
                                {
                                    FolderName = "Final Product",
                                    NavURL = "", //TODO
                                    ChildFolders = null
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
