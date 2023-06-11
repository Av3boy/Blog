namespace Blog
{
    /// <summary>
    ///    Represents a blog as a blazor component.
    /// </summary>
    public class BlogDto
    {
        /// <summary>Gets or sets the Title of the blog.</summary>
        public required string Title { get; set; } = string.Empty;

        /// <summary>Gets or sets the date when the Date was published.</summary>
        public required DateTime PublishDate { get; set; }

        /// <summary>Gets or sets the name of the person who wrote the blog.</summary>
        public string Author { get; set; } = "Antti Veikkolainen";

        /// <summary>Get or sets the Tags by which the blog can be searched.</summary>
        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

        /// <summary>Gets or sets the URL of the blog.</summary>
        public string URL { get; set; } = string.Empty;

        /// <summary>Gets or sets the type of the blazor component.</summary>
        public Type BlogContentComponentType { get; set; } = default!;
    }
}
