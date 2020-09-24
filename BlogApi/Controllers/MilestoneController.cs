using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApi.Models;
using BlogApi.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("[controller]")]
    public class MilestoneController : Controller
    {
        private async Task<IEnumerable<Milestone>> GetAllMilestones()
        {
            string url = "https://api.github.com/repos/leoyoung07/blog/milestones";
            return await GithubApiUtil.GetDataOrElse(url, () => new List<Milestone>());
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetMilestoneList()
        {
            return Ok(await this.GetAllMilestones());
        }
    }
}
