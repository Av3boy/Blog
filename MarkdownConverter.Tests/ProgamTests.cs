namespace MarkdownConverter.Tests
{
    public class ProgamTests
    {
        [Fact]
        public void Main()
        {
            int result = Program.Main();

        }

        [Fact]
        public void ConvertMarkdownToRazor()
        {
            Program.ConvertMarkdownToRazor(Program.BlogPath, out string razorFileName);

            // TODO: Check file is in from RazorPath
        }

        [Fact]
        public void GetHtmlContents()
        {
            string markdownContents = "";
            string htmlContents = Program.GetHtmlContents(markdownContents);

        }

        [Fact]
        public void CreateRazorFile()
        {
            string htmlContents = "";
            Program.CreateRazorFile(htmlContents, Program.RazorPath);

        }

        [Fact]
        public void GetRazorFileNameWithPath()
        {
            string markdownFile = "";
            string razorFileWithPath = Program.GetRazorFileNameWithPath(markdownFile, out string razorFile);

        }

        [Fact]
        public void GetMarkdownContents()
        {
            string markdownPath = "";
            string markdown = Program.GetMarkdownContents(markdownPath);

        }

        [Fact]
        public void MdFileNameToRazorFileName()
        {
            string markdownFileName = "";
            string razorFileName = Program.MdFileNameToRazorFileName(markdownFileName);

        }
    }
}