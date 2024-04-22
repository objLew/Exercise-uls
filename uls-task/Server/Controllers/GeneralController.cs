using GeneralLibrary;
using Microsoft.AspNetCore.Mvc;

namespace uls_task.Server.Controllers
{
    /// <summary>
    /// Define specific routing and apply authorization filter to ALL functions
    /// </summary>
    [ApiController]
    [Route("api/calculator")]
    [TypeFilter(typeof(AuthorizationFilter))]
    public class GeneralController : Controller
    {
        [HttpGet]
        [Route("CalculateString")]
        public IActionResult CalculateString(string CalculateThis)
        {
            try
            {
                bool isValidString = DecodeHelper.SanityCheckInput(CalculateThis);

                if (!isValidString)
                {
                    return BadRequest("Input string is invalid");
                }
            }
            catch 
            {
                return BadRequest("Input string is invalid");
            }







            return BadRequest();

            return View();
        }
    }
}
