using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers
{
    public class MainApiController : Controller
    {
        [ApiController]
        [Route("/api/[controller]")]
        // GET: MainApiController

        [HttpPost]
        public async Task AddNewUser([FromBody]NewUserModel model)
        {
            throw new NotImplementedException();
        }

    }
}
