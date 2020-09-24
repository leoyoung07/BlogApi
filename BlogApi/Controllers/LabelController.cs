using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlogApi.Models;
using BlogApi.Utils;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {
        public async Task<IEnumerable<Label>> GetAllLabels()
        {
            string url = "https://api.github.com/repos/leoyoung07/blog/labels";
            return await GithubApiUtil.GetDataOrElse(url, () => new List<Label>());
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetLabelList()
        {
            return Ok(await GetAllLabels());
        }
    }
}