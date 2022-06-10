using DemoBusinessLogic;
using DemoBusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Contact_Book_Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
       
        public async Task<IActionResult> Get(string userId)
        {
            try
            {
                return Ok(await _userService.GetUser(userId));
            }
            catch(ArgumentException arex)
            {
                return BadRequest(arex.Message);    
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UpdateRequestDTO update)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
                      var result = await _userService.UpdateUser(userId, update);
                    return NoContent();
            }
            catch(MissingMemberException mmex)
            {
                return BadRequest(mmex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
      
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                var result =await _userService.DeleteUser(userId);
                return Ok(result);  
            }
            catch (MissingMemberException)
            {
                return NotFound();
            }
            catch(ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
