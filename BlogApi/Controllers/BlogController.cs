using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        private async Task<IEnumerable<GithubIssue>> GetAllBlogs()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .UserAgent
                    .TryParseAdd("C# HttpClient");
                string url = "https://api.github.com/repos/leoyoung07/blog/issues?state=closed&assignee=leoyoung07";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<GithubIssue> blogs = await response.Content.ReadAsAsync<IEnumerable<GithubIssue>>();
                    return blogs;
                }
                else
                {
                    return new List<GithubIssue>();
                }
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetBlogList(
            [FromQuery(Name = "q")] string query,
            [FromQuery(Name = "tag")] string label,
            [FromQuery(Name = "archive")] string milestone
        )
        {
            IEnumerable<GithubIssue> blogs = await this.GetAllBlogs();
            if (!string.IsNullOrEmpty(query))
            {
                blogs = blogs.Where(blog =>
                    blog.Body.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    blog.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
                );
            }
            if (!string.IsNullOrEmpty(label))
            {
                blogs = blogs.Where(blog => blog.Labels.Exists(l => l.Name.Equals(label, StringComparison.OrdinalIgnoreCase)));
            }
            if (!string.IsNullOrEmpty(milestone))
            {
                blogs = blogs.Where(blog => blog.Milestone != null && blog.Milestone.Title.Equals(milestone, StringComparison.OrdinalIgnoreCase));
            }
            return Ok(blogs.ToList());
        }
    }
}
