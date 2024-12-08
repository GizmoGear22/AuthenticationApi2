using System.ComponentModel.DataAnnotations;
using AuthenticationLayer;
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
        private readonly ITokenGeneration _tokenGen;
        public MainApiController(IApiAccessLogic accessLogic, ILogger<MainApiController> logger, ITokenGeneration tokenGen)
        {
            _accessLogic = accessLogic;
            _logger = logger;
            _tokenGen = tokenGen;
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
                if (user == true)
                {
                    //var token = _tokenGen.GenerateJSONToken(model)
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured");
            }

        }
        

    }
}
