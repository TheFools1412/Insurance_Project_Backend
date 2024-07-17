using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Project.Controllers
{
    [Route("api/history")]
    public class HistoryController : Controller
    {


        private HistoryService historyService;

        private IConfiguration _configuration;

        private IWebHostEnvironment webHostEnvironment;

        public HistoryController(HistoryService _historyService, IConfiguration configuration, IWebHostEnvironment _env)
        {
            historyService = _historyService;
            _configuration = configuration;
            webHostEnvironment = _env;
        }
        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(historyService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("findId/{id}")]
        [Produces("application/json")]// tra ve Json
        public IActionResult FindID(int id)
        {
            try
            {
                return Ok(historyService.FindID(id));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}