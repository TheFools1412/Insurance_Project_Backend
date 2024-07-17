﻿using Insurance_Project.Models;
using Insurance_Project.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Insurance_Project.Controllers;
[Route("api/payment")]
public class PaymentController : Controller
{


    private PaymentService paymentService;
    private IConfiguration _configuration;
    private IWebHostEnvironment _env;

    public PaymentController(PaymentService _paymentService, IConfiguration configuration, IWebHostEnvironment env)
    {
        paymentService = _paymentService;
        _configuration = configuration;
        _env = env;
    }
    [Consumes("application/json")]
    [HttpGet("findall")]
    public IActionResult FindAll()
    {
        try
        {
            return Ok(paymentService.findAll());
        }
        catch
        {
            return BadRequest();
        }
    }
    //[Consumes("multipart/form-data")]
    //[Produces("application/json")]// tra ve Json
    //[HttpPost("create")]
    //public IActionResult Create(string strcontract)
    //{
    //    try
    //    {
    //        Debug.WriteLine(strcontract);

    //        var contract = JsonConvert.DeserializeObject<Contract>(strcontract);



    //        bool result = contractService.Create(contract);

    //        return Ok(new
    //        {
    //            Result = result
    //        });
    //    }
    //    catch
    //    {
    //        return BadRequest();
    //    }
    //}


    //[Consumes("application/json")]
    //[Produces("application/json")]// tra ve Json
    //[HttpPut("update")]
    //public IActionResult Update([FromBody] Contract contract)
    //{
    //    try
    //    {
    //        return Ok(new
    //        {
    //            result = contractService.Update(contract)
    //        });
    //    }
    //    catch
    //    {
    //        return BadRequest();
    //    }
    //}
    //[Consumes("multipart/form-data")]
    //[HttpGet("find/{id}")]
    //[Produces("application/json")]// tra ve Json
    //public IActionResult Find(int id)
    //{
    //    try
    //    {
    //        return Ok(contractService.find(id));
    //    }
    //    catch
    //    {
    //        return BadRequest();
    //    }
    //}
    //[HttpGet("find/{email}")]
    //[Produces("application/json")]// tra ve Json
    //public IActionResult Find(string email)
    //{
    //    try
    //    {
    //        return Ok(contractService.Find(email));
    //    }
    //    catch
    //    {
    //        return BadRequest();
    //    }
    //}
    [Consumes("multipart/form-data")]
    [HttpGet("findId/{id}")]
    [Produces("application/json")]// tra ve Json
    public IActionResult FindID(int id)
    {
        try
        {
            return Ok(paymentService.FindID(id));
        }
        catch
        {
            return BadRequest();
        }
    }
}
