﻿using Microsoft.Extensions.Caching.Memory;

namespace Blog.DependencyInjection.Services
{
    /// <inheritdoc />
    public class BlogCache : IBlogCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly HashSet<string> _blogUrlKeys;

        /// <summary>
        ///     Initializes the blog cache.
        /// </summary>
        /// <param name="memoryCache">The memory cache object where the blogs are stored.</param>
        public BlogCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _blogUrlKeys = new HashSet<string>();
        }

        /// <inheritdoc />
        public BlogDto? GetBlog(string blogUrl)
        {
            return _memoryCache.Get<BlogDto>(blogUrl);
        }

        /// <inheritdoc />
        public void SetItem(string blogUrl, BlogDto blog)
        {
            _memoryCache.Set(blogUrl, blog);
            _blogUrlKeys.Add(blogUrl);
        }

        /// <inheritdoc />
        public IEnumerable<BlogDto> GetAllBlogs()
        {
            foreach (var key in _blogUrlKeys)
            {
                _memoryCache.TryGetValue(key, out BlogDto? blog);
                yield return blog!;
            }
        }

        /// <inheritdoc />
        public IEnumerable<BlogDto> GetBlogsByTag(params string[] tags)
        {
            foreach (var blog in GetAllBlogs())
            {
                if (blog.Tags.Any(tag => tags.Contains(tag)))
                {
                    yield return blog;
                }
            }
        }
    }
}
