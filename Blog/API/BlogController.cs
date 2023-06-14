using Blog.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API
{
    /// <summary>Handles blogs through REST API endpoints.</summary>
    [Route("api/blogs")]
    public class BlogController : Controller
    {
        private readonly IBlogCache _blogCache;

        /// <summary>Initializes the Blogs API.</summary>
        public BlogController(IBlogCache blogCache)
        {
            _blogCache = blogCache;
        }

        /// <summary>
        ///     Gets all the blogs.
        /// </summary>
        /// <returns>
        ///     All the found blogs.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var blogs = _blogCache.GetAllBlogs();

            if (blogs is null || !blogs.Any())
                return StatusCode(StatusCodes.Status204NoContent);

            return StatusCode(StatusCodes.Status200OK, blogs);
        }
    }
}
