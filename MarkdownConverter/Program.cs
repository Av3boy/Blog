using System.Text;

namespace MarkdownConverter;

public class Program
{
    private static string _path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..");
    private static string _blogPath = Path.Combine(_path, "Blogs");
    private static string _razorPath = Path.Combine(_path, @"Blog\Components\Blogs");

    public static int Main()
    {
        // Get markdown files
        var files = Directory.GetFiles(_blogPath);

        // Convert to razor components
        foreach (var file in files)
        {
            if (Convert(file, out string razorFile))
                Console.WriteLine($"Converted '{razorFile}'.");
        }

        return 0;
    }

    private static bool Convert(string file, out string razorFile)
    {
        // Get new razor file path
        razorFile = $"{Path.GetFileNameWithoutExtension(file)}.razor";
        string razorFilePath = Path.Combine(_razorPath, razorFile);

        // Get new razor component contents
        string contents;
        using (StreamReader streamReader = new StreamReader(file, Encoding.UTF8))
        {
            contents = streamReader.ReadToEnd();
        }

        string html = Markdig.Markdown.ToHtml(contents);

        using (StreamWriter sw = new StreamWriter(razorFilePath, false))
        {
            sw.Write(html);
        }

        return true;
    }
}