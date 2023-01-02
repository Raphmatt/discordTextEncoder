namespace UrlConverter;

public class FileManager
{
    public static string WriteTextToTmpFile(string text)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        
        string filename = "clipboard.txt";
        
        File.WriteAllText(filename, text);
        return Path.Combine(baseDir, filename);
    }
}