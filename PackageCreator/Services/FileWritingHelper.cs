namespace PackageCreator.Services;

public class FileWritingHelper
{
    public static void ReplaceLine(string filePath, string oldValue, string newValue)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file does not exist.", filePath);

        var lines = File.ReadAllLines(filePath);
        for (var i = 0; i < lines.Length; i++)
            if (lines[i].Contains(oldValue))
                lines[i] = lines[i].Replace(oldValue, newValue);

        File.WriteAllLines(filePath, lines);
    }
}