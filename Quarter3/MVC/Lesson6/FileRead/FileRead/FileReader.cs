using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRead
{
    internal class FileReader
    {
        public async Task<List<FileContent>> ReadAsync(string[] args)
        {
            List<FileContent> list = new();
            foreach (var file in args) {
                FileContent fileContent = new FileContent();
                if (File.Exists(file)) {
                    using (StreamReader reader = new StreamReader(file)) {
                        fileContent.File = file;
                        string? line;
                        while ((line = await reader.ReadLineAsync()) != null) {
                            fileContent.Lines.Add(line);
                        }
                    }
                }
                list.Add(fileContent);
            }
            return list;
        }

    }
}
