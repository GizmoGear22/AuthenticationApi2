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
        private readonly ILogger<MainApiController> _logger;
        public MainApiController(IApiAccessLogic accessLogic, ILogger<MainApiController> logger)
        {
            _accessLogic = accessLogic;
            _logger = logger;
        }
        [HttpPost]
        [Route("/NewUser")]
        public async Task AddNewUser([FromBody]NewUserModel model)
        {
                await _accessLogic.AddUser(model);
        }

        
        [HttpPost]
        [Route("/UserLogin")]
        public async Task UserLogin([FromBody]UserLoginModel model)
        {
            try
            {
                bool user = await _accessLogic.CheckUserCredentials(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured");
            }

        }
        

    }
}
