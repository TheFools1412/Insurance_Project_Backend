using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Project.Controllers;
[Route("api/insurance")]
public class InsuranceController : Controller
{


    private InsuraceService insuraceService;
    private IConfiguration _configuration;
    private IWebHostEnvironment _env;

    public InsuranceController(InsuraceService _insuraceService, IConfiguration configuration, IWebHostEnvironment env)
    {
        insuraceService = _insuraceService;
        _configuration = configuration;
        _env = env;
    }
    [Consumes("application/json")]
    [HttpGet("findall")]
    public IActionResult FindAll()
    {
        try
        {
            return Ok(insuraceService.findAll());
        }
        catch
        {
            return BadRequest();
        }
    }
    [Consumes("application/json")]
    [Produces("application/json")]// tra ve Json
    [HttpPost("create")]
    public IActionResult Create([FromBody] Insurance insurance)
    {
        try
        {
            return Ok(new
            {
                result = insuraceService.Create(insurance)
            });
        }
        catch
        {
            return BadRequest();
        }
    }


    [Consumes("application/json")]
    [Produces("application/json")]// tra ve Json
    [HttpPut("update")]
    public IActionResult Update([FromBody] Insurance insurance)
    {
        try
        {
            return Ok(new
            {
                result = insuraceService.Update(insurance)
            });
        }
        catch
        {
            return BadRequest();
        }
    }
    [Consumes("multipart/form-data")]
    [HttpGet("find/{id}")]
    [Produces("application/json")]// tra ve Json
    public IActionResult Find(int id)
    {
        try
        {
            return Ok(insuraceService.find(id));
        }
        catch
        {
            return BadRequest();
        }
    }
}
