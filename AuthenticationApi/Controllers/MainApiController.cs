using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MainApiController : Controller
    {
        [HttpPost]
        public async Task AddNewUser([FromBody]NewUserModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task CheckUserCredentials([FromBody]LoginModel model)
        {
            throw new NotImplementedException();
        }

    }
}
