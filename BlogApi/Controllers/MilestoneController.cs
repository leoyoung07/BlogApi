using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("[controller]")]
    public class MilestoneController : Controller
    {
        private async Task<IEnumerable<Milestone>> GetAllMilestones()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .UserAgent
                    .TryParseAdd("C# HttpClient");
                string url = "https://api.github.com/repos/leoyoung07/blog/milestones";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Milestone> milestones = await response.Content.ReadAsAsync<IEnumerable<Milestone>>();
                    return milestones;
                }
                else
                {
                    return new List<Milestone>();
                }
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetMilestoneList()
        {
            return Ok(await this.GetAllMilestones());
        }
    }
}
