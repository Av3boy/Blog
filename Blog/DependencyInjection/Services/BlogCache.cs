using Microsoft.Extensions.Caching.Memory;

namespace Blog.DependencyInjection.Services
{
    /// <inheritdoc />
    public class BlogCache : IBlogCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly HashSet<string> _blogNameKeys;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryCache"></param>
        public BlogCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _blogNameKeys = new HashSet<string>();
        }

        /// <inheritdoc />
        public BlogDto? GetBlog(string blogName)
        {
            return _memoryCache.Get<BlogDto>(blogName);
        }

        /// <inheritdoc />
        public void SetItem(string blogName, BlogDto blog)
        {
            _memoryCache.Set(blogName, blog);
            _blogNameKeys.Add(blogName);
        }

        /// <inheritdoc />
        public IEnumerable<BlogDto> GetAllBlogs()
        {
            foreach (var key in _blogNameKeys)
            {
                _memoryCache.TryGetValue(key, out BlogDto? blog);
                yield return blog!;
            }
        }
    }
}
