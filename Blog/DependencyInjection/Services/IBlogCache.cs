namespace Blog.DependencyInjection.Services;

/// <summary>Stores all the available blogs</summary>
public interface IBlogCache
{
    /// <summary>
    ///     Retrieves all the blogs from the cache.
    /// </summary>
    /// <returns>
    ///     All the blogs in the cache.
    /// </returns>
    public IEnumerable<BlogDto> GetAllBlogs();
    
    /// <summary>
    ///     Retrieves a single blog from the cache with the given <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The identifier of the blog in the cache.</param>
    /// <returns>
    ///     A blog item from the cache if it exists; otherwise, <see langword="null"/>.
    /// </returns>
    BlogDto? GetBlog(string key);
    
    /// <summary>
    ///     Adds a new blog to the cache.
    /// </summary>
    /// <param name="key">The key by which the cache item can be later fetched with..</param>
    /// <param name="blog">The blog to be cached.</param>
    void SetItem(string key, BlogDto blog);

    /// <summary>
    ///     Gets all the blogs with the given <paramref name="tags"/>.
    /// </summary>
    /// <param name="tags">A list of tags by which the tags are searched with.</param>
    /// <returns>
    ///     A list of all the blogs with the given <paramref name="tags"/>.
    /// </returns>
    IEnumerable<BlogDto> GetBlogsByTag(params string[] tags);
}
