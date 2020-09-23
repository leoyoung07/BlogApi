using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {
        public async Task<IEnumerable<Label>> GetAllLabels()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .UserAgent
                    .TryParseAdd("C# HttpClient");
                string url = "https://api.github.com/repos/leoyoung07/blog/labels";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Label> labels = await response.Content.ReadAsAsync<IEnumerable<Label>>();
                    return labels;
                }
                else
                {
                    return new List<Label>();
                }
            }
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetLabelList()
        {
            return Ok(await GetAllLabels());
        }
    }
}