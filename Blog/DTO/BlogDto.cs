namespace Blog
{
    /// <summary>
    ///    Represents a blog as a blazor component.
    /// </summary>
    public class BlogDto
    {
        /// <summary>Gets or sets the URL of the blog.</summary>
        public string URL { get; set; } = string.Empty;

        /// <summary>Gets or sets the type of the blazor component.</summary>
        public Type BlogContentComponentType { get; set; } = default!;
    }
}
