using Castle.Core.Resource;
using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Insurance_Project.Controllers;
[Route("api/account")]
public class AccountController : Controller
{


    private CustomerService customerService;
    private IConfiguration _configuration;
    private IWebHostEnvironment _env;

    public AccountController(CustomerService _customerService, IConfiguration configuration, IWebHostEnvironment env)
    {
        customerService = _customerService;
        _configuration = configuration;
        _env = env;
    }


    [Consumes("application/json")]
    [HttpPost("login")]
    public IActionResult Login()
    {
        try
        {
            return Ok(customerService.findAll());
        }
        catch
        {
            return BadRequest();
        }
    }

}
