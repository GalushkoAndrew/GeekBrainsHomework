using System;
using System.Collections.Generic;
using System.IO;

namespace GeekBrains.Learn.FolderTree
{
    class Program
    {
        /// <summary>
        /// Имя корневой папки для построения дерева
        /// </summary>
        const string rootFolderName = "Example";

        static void Main(string[] args)
        {
            CreateFolders();

            var fileName = "folderListRecursion.txt";
            File.Create(fileName).Close();
            FolderListRecursion(Path.Combine(Directory.GetCurrentDirectory(), rootFolderName), fileName);

            fileName = "folderListNoRecursion.txt";
            FolderListNoRecursion(Path.Combine(Directory.GetCurrentDirectory(), rootFolderName), fileName);
        }

        /// <summary>
        /// Строит без рекурсии список папок
        /// </summary>
        /// <param name="folderPath">путь к папке для построения дерева</param>
        /// <param name="fileName">файл, в который сохраняется список</param>
        static void FolderListNoRecursion(string folderPath, string fileName)
        {
            File.Create(fileName).Close();
            PrintToFileFolderAndFiles(folderPath, fileName);
            var arrayPath = Directory.GetDirectories(folderPath, "*.*", SearchOption.AllDirectories);
            foreach (var item in arrayPath)
            {
                PrintToFileFolderAndFiles(item, fileName);
            }
        }

        /// <summary>
        /// Записывает в файл пути к текущей папке и найденным в ней файлам
        /// </summary>
        /// <param name="folderPath">путь к папке</param>
        /// <param name="fileName">файл, в который сохраняется список</param>
        static void PrintToFileFolderAndFiles(string folderPath, string fileName)
        {
            File.AppendAllText(fileName, folderPath + Environment.NewLine);
            var arrayFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in arrayFiles)
                File.AppendAllText(fileName, file + Environment.NewLine);
        }

        /// <summary>
        /// Строит рекурсией список папок и файлов в ней
        /// и сохраняет список в файл
        /// </summary>
        /// <param name="folderPath">путь к папке для построения дерева</param>
        /// <param name="fileName">файл, в который сохраняется список</param>
        static void FolderListRecursion(string folderPath, string fileName)
        {
            File.AppendAllText(fileName, folderPath + Environment.NewLine);
            var arrayFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in arrayFiles)
                File.AppendAllText(fileName, file + Environment.NewLine);

            var arrayPath = Directory.GetDirectories(folderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var item in arrayPath)
                FolderListRecursion(item, fileName);
        }

        /// <summary>
        /// Создает дерево папок с файлами для тестирования
        /// </summary>
        static void CreateFolders()
        {
            var appFolder = Directory.GetCurrentDirectory();
            var rootFolderFullName = Directory.CreateDirectory(Path.Combine(appFolder, rootFolderName)).FullName;

            Directory.CreateDirectory(Path.Combine(rootFolderFullName, "Folder1Lvl1"));
            Directory.CreateDirectory(Path.Combine(rootFolderFullName, "Folder2Lvl1"));

            var parentFolder = Path.Combine(rootFolderFullName, "Folder1Lvl1");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder3Lvl2"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder4Lvl2"));
            File.Create(Path.Combine(parentFolder, "test1.txt"));

            parentFolder = Path.Combine(rootFolderFullName, "Folder2Lvl1");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder5Lvl2"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder6Lvl2"));
            File.Create(Path.Combine(parentFolder, "test2.txt"));
            File.Create(Path.Combine(parentFolder, "test3.txt"));

            parentFolder = Path.Combine(rootFolderFullName, "Folder1Lvl1", "Folder3Lvl2");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder7Lvl3"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder8Lvl3"));
            File.Create(Path.Combine(parentFolder, "test4.txt"));
            File.Create(Path.Combine(parentFolder, "test5.txt"));

            parentFolder = Path.Combine(rootFolderFullName, "Folder1Lvl1", "Folder4Lvl2");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder9Lvl3"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder10Lvl3"));
            File.Create(Path.Combine(parentFolder, "test6.txt"));
            File.Create(Path.Combine(parentFolder, "test7.txt"));

            parentFolder = Path.Combine(rootFolderFullName, "Folder2Lvl1", "Folder5Lvl2");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder11Lvl3"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder12Lvl3"));
            File.Create(Path.Combine(parentFolder, "test8.txt"));

            parentFolder = Path.Combine(rootFolderFullName, "Folder1Lvl1", "Folder4Lvl2", "Folder9Lvl3");
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder13Lvl4"));
            Directory.CreateDirectory(Path.Combine(parentFolder, "Folder14Lvl4"));
            File.Create(Path.Combine(parentFolder, "test9.txt"));
            File.Create(Path.Combine(parentFolder, "test10.txt"));
            File.Create(Path.Combine(parentFolder, "test11.txt"));
            File.Create(Path.Combine(parentFolder, "test12.txt"));

            File.Create(Path.Combine(Path.Combine(parentFolder, "Folder13Lvl4", "test13.txt")));
        }
    }
}
