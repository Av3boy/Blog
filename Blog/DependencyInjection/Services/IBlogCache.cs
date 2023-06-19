namespace Blog.DependencyInjection.Services;

/// <summary>Stores all the available blogs</summary>
public interface IBlogCache
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BlogDto> GetAllBlogs();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="blogName"></param>
    /// <returns></returns>
    BlogDto? GetBlog(string blogName);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="blogName"></param>
    /// <param name="blog"></param>
    void SetItem(string blogName, BlogDto blog);
}
