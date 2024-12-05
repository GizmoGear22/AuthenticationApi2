using System.ComponentModel.DataAnnotations;
using LogicLayer.ApiLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MainApiController : Controller
    {

        private readonly IApiAccessLogic _accessLogic;
        public MainApiController(IApiAccessLogic accessLogic)
        {
            _accessLogic = accessLogic;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody]NewUserModel model)
        {
            try
            {
                await _accessLogic.AddUser(model);
                return Ok(model);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /*
        [HttpPost]
        public async Task CheckUserCredentials([FromBody]LoginModel model)
        {
            throw new NotImplementedException();
        }
        */

    }
}
