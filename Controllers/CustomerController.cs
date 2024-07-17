using Castle.Core.Resource;

using Insurance_Project.Helpers;
using Insurance_Project.Models;
using Insurance_Project.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace Insurance_Project.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {


        private CustomerService customerService;

        private IConfiguration configuration;

        private IWebHostEnvironment webHostEnvironment;

        public CustomerController(CustomerService _customerService, IConfiguration _configuration, IWebHostEnvironment _env)
        {
            customerService = _customerService;
            configuration = _configuration;
            webHostEnvironment = _env;
        }
        [Produces("application/json")]
        [HttpGet("findallcustomer")]
        public IActionResult FindAll()
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
        [Consumes("multipart/form-data")]
        [Produces("application/json")]// tra ve Json
        [HttpPost("create")]

        public IActionResult Create(IFormFile profilePhoto, string strcustomer)
        {
            Debug.WriteLine("-------" + strcustomer);

            var customer = JsonConvert.DeserializeObject<Customer>(strcustomer);

            var fileName = FileHelper.genarateFileName(profilePhoto.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                profilePhoto.CopyTo(fileStream);
            }
            customer.ProfilePhoto = fileName;

            //var password = BCrypt.Net.BCrypt.HashPassword(customer.Password);

            String content = RandomHelper.RandomInt(6);

            Debug.WriteLine(customer);

            if (customerService.Exists(customer.Email))
            {
                return Ok(new { result = " Email already" });
            }
            else
            {
                try
                {
                    //var mailHelper = new MailHelper(configuration);

                    //var contentInput = "Your activation code is <h3>" + content + "</h3>";

                    //var statusSendEmail = mailHelper.Send(configuration["Gmail:UserName"], customer.Email, "Security Alert", contentInput);
                    ////customer.Securitycode = content;
                    //customer.Password = password;
                    //customer.Status = true;

                    return Ok(new { result = customerService.Create(customer) });
                    //if (customer != null)
                    //{
                    //    
                    //}
                    //else
                    //{
                    //    return Ok(new { result = "Send email Invalid" });
                    //}
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return BadRequest(ex.Message);
                }
            }
        }




        [HttpGet("findId/{id}")]
        [Produces("application/json")]// tra ve Json
        public IActionResult FindID(int id)
        {
            try
            {
                return Ok(customerService.FindID(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [Produces("application/json")]
        [Consumes("application/json")]
        //[Consumes("multipart/form-data")]
        public IActionResult Login([FromBody] Customer customer)
        {
            try
            {
                return Ok(new
                {
                    result = customerService.login(customer.Email, customer.Password),

                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find/{email}")]
        [Produces("application/json")]// tra ve Json
        public IActionResult Find(string email)
        {
            try
            {
                return Ok(customerService.Find(email));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]// tra ve Json
        [HttpPut("update")]
        public IActionResult Update([FromBody] Customer customer)
        {
            try
            {
                return Ok(new
                {
                    result = customerService.Update(customer)
                });
            }
            catch
            {
                return BadRequest();
            }
        }




        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    result = customerService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}