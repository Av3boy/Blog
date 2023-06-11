using System.Globalization;
using System.Text;

namespace MarkdownConverter;

public class Program
{
    private static readonly string _path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..");
    private static readonly string _blogPath = Path.Combine(_path, @"Blog\Blogs");
    private static readonly string _razorPath = Path.Combine(_path, @"Blog\Blogs\Components");

    /// <summary>
    ///     Marks the entry point of the application.
    /// </summary>
    /// <returns>
    ///     The exit code of the application. 0 if the application was successful.
    /// </returns>
    public static int Main()
    {
        // Get  the markdown files.
        var files = Directory.GetFiles(_blogPath, "*.md");

        // Convert markdown files to razor components to be consumed by the blog app.
        foreach (var file in files)
        {
            ConvertMarkdownToRazor(file, out string razorFile);
            Console.WriteLine($"Converted '{razorFile}'.");
        }

        return 0;
    }

    /// <summary>
    ///     Converts the given <paramref name="markdownFileWithPath"/> to a razor component.
    /// </summary>
    /// <param name="markdownFileWithPath">The file to be converted.</param>
    /// <param name="razorFileName">The name of the newly created razor file.</param>
    private static void ConvertMarkdownToRazor(string markdownFileWithPath, out string razorFileName)
    {
        string markdownContents = GetMarkdownContents(markdownFileWithPath);
        string htmlContents = GetHtmlContents(markdownContents);
        string razorFileWithPath = GetRazorFileNameWithPath(markdownFileWithPath, out razorFileName);

        CreateRazorFile(htmlContents, razorFileWithPath);
    }

    /// <summary>
    ///    Converts the given <paramref name="markdownContents"/> to html.
    /// </summary>
    /// <param name="markdownContents">The markdown to be converted into HTML.</param>
    /// <returns>
    ///     The HTML representation of the given <paramref name="markdownContents"/>.
    /// </returns>
    private static string GetHtmlContents(string markdownContents)
        => Markdig.Markdown.ToHtml(markdownContents);

    /// <summary>
    ///     Creates a razor file with the given <paramref name="htmlContents"/>.
    /// </summary>
    /// <param name="htmlContents">The contents of the new razor component.</param>
    /// <param name="razorFileWithPath">The razor file with a path to be created.</param>
    private static void CreateRazorFile(string htmlContents, string razorFileWithPath)
    {
        using (StreamWriter sw = new StreamWriter(razorFileWithPath, false))
        sw.Write(htmlContents);
    }

    /// <summary>
    ///     Gets the name and path of the razor component.
    /// </summary>
    /// <param name="markdownFile">The markdown file name to be converted into a razor component name.</param>
    /// <param name="razorFile">Outputs the name of the new razor file with it's path.</param>
    /// <returns>
    ///     The razor files name with a path.
    /// </returns>
    private static string GetRazorFileNameWithPath(string markdownFile, out string razorFile)
    {
        string markdownFileName = Path.GetFileNameWithoutExtension(markdownFile);
        razorFile = string.Concat(MdFileNameToRazorFileNae(markdownFileName), ".razor");
        return Path.Combine(_razorPath, razorFile);
    }

    /// <summary>
    ///     Reads the contents from the given <paramref name="markdownPath"/>.
    /// </summary>
    /// <param name="markdownPath">The path to a markdown file.</param>
    /// <returns>
    ///     The contents of the markdown file.
    /// </returns>
    private static string GetMarkdownContents(string markdownPath)
    {
        using (StreamReader streamReader = new StreamReader(markdownPath, Encoding.UTF8))
        return streamReader.ReadToEnd();
    }

    /// <summary>
    ///     Converts the given 'kebab-case' <paramref name="markdownFileName"/> to a 'Camel-Case' razor file name.
    /// <para>
    ///     Read about razor component naming 
    ///     <see cref="https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-7.0#component-name-class-name-and-namespace">here</see>.
    /// </para>
    /// </summary>
    ///     <param name="markdownFileName">The name of the markdown file to be converted.</param>
    /// <returns>
    ///     The converted 'Camel-Case' razor file name.
    /// </returns>
    private static string MdFileNameToRazorFileNae(string markdownFileName)
    {
        StringBuilder builder = new StringBuilder();

        if (string.IsNullOrWhiteSpace(markdownFileName))
        {
            throw new ArgumentNullException(nameof(markdownFileName));
        }

        // Allocate the lenght of the name + the new hyphens to be added before the capital letters
        var pascalCase = new StringBuilder(markdownFileName.Length + markdownFileName.Count(char.IsUpper));
        var words = markdownFileName.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            string pascalCaseWord = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
            pascalCase.Append(pascalCaseWord);
        }

        return pascalCase.ToString();
    }
}