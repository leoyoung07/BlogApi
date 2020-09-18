using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController: ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetLabelList()
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
                    string labels = await response.Content.ReadAsStringAsync();
                    return Ok(labels);
                }
                else
                {
                    return Ok("[]");
                }
            }
        }
    }
}