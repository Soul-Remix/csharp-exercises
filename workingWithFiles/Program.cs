using System.Text.Json;

namespace WorkingWithFiles;

class MyProgram
{
    static void Main()
    {
        string thisDirectory = Directory.GetCurrentDirectory();
        string storesPath = Path.Combine(thisDirectory, "stores");
        string salesTotalPath = Path.Combine(thisDirectory, "salesTotalDir");


        var files = GetFiles(storesPath);

        var salesTotal = ClaculateSalesTotal(files);

        if (!Directory.Exists(salesTotalPath))
        {
            Directory.CreateDirectory(salesTotalPath);
        }

        File.AppendAllText(Path.Combine(salesTotalPath, "salesTotal"), $"{salesTotal} {Environment.NewLine}");
    }

    public static IEnumerable<string> GetFiles(string path)
    {
        IEnumerable<string> allFiles = Directory.EnumerateFiles(path, "", SearchOption.AllDirectories);
        List<string> files = new List<string>();

        foreach (string file in allFiles)
        {
            if (Path.GetExtension(file) == ".json")
            {
                files.Add(file);
            }
        }

        return files;
    }

    public static decimal ClaculateSalesTotal(IEnumerable<string> files)
    {
        decimal salesTotal = 0;

        foreach (string file in files)
        {
            string jsonString = File.ReadAllText(file);
            SalesTotal? sales = JsonSerializer.Deserialize<SalesTotal>(jsonString);
            salesTotal += sales?.Total ?? 0;
        }

        return salesTotal;
    }

}

record SalesTotal
{
    public decimal Total { get; set; }
}