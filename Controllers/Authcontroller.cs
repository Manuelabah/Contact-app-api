using DemoBusinessLogic;
using DemoBusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact_Book_Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
   
    public class Authcontroller : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public Authcontroller(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpPost("Login")]
       
        public async Task<IActionResult> Login(UserRequestDTO requestDTO)
        {
            try
            {
               return  Ok(await _authentication.Login(requestDTO));
            }
            catch(AccessViolationException aVEx)
            {
                return BadRequest(aVEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationRequestDTO registrationRequest)
        {
            try
            {
                var result = await _authentication.Register(registrationRequest);
                
                return Created("", result);
            }
            catch (MissingFieldException ex)
            {
                return BadRequest(ex.Message);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
