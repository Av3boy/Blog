using System.Globalization;
using System.Text;

namespace MarkdownConverter;

public class Program
{
    public static readonly string Path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\..");
    public static readonly string BlogPath = System.IO.Path.Combine(Path, @"Blog\Blogs");
    public static readonly string RazorPath = System.IO.Path.Combine(Path, @"Blog\Blogs\Components");

    /// <summary>
    ///     Marks the entry point of the application.
    /// </summary>
    /// <returns>
    ///     The exit code of the application. 0 if the application was successful.
    /// </returns>
    public static int Main()
    {
        // Get  the markdown files.
        var files = Directory.GetFiles(BlogPath, "*.md");

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
    public static void ConvertMarkdownToRazor(string markdownFileWithPath, out string razorFileName)
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
    public static string GetHtmlContents(string markdownContents)
        => Markdig.Markdown.ToHtml(markdownContents);

    /// <summary>
    ///     Creates a razor file with the given <paramref name="htmlContents"/>.
    /// </summary>
    /// <param name="htmlContents">The contents of the new razor component.</param>
    /// <param name="razorFileWithPath">The razor file with a path to be created.</param>
    public static void CreateRazorFile(string htmlContents, string razorFileWithPath)
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
    public static string GetRazorFileNameWithPath(string markdownFile, out string razorFile)
    {
        string markdownFileName = System.IO.Path.GetFileNameWithoutExtension(markdownFile);
        razorFile = string.Concat(MdFileNameToRazorFileName(markdownFileName), ".razor");
        return System.IO.Path.Combine(RazorPath, razorFile);
    }

    /// <summary>
    ///     Reads the contents from the given <paramref name="markdownPath"/>.
    /// </summary>
    /// <param name="markdownPath">The path to a markdown file.</param>
    /// <returns>
    ///     The contents of the markdown file.
    /// </returns>
    public static string GetMarkdownContents(string markdownPath)
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
    public static string MdFileNameToRazorFileName(string markdownFileName)
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