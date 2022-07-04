using FileRead;

FileReader fileReader = new FileReader();
var result = await fileReader.ReadAsync(args);
string text = "";
foreach (var item in result) {
    text += "File:" + item.File;
    text += ", Lines: " + item.Lines.Count.ToString() + "; ";
}
Console.WriteLine("Reading files is done. " + text);