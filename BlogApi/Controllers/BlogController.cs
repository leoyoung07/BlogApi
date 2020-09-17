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

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetBlogList()
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
                    string blogs = await response.Content.ReadAsStringAsync();
                    return Ok(blogs);
                }
                else
                {
                    return Ok("[]");
                }
            }
        }
    }
}
