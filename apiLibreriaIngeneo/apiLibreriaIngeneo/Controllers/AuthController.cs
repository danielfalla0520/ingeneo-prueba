using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiLibreriaIngeneo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult<Model.Response.LoginResponse> Login(Model.Request.LoginRequest request)
        {
            Model.Response.LoginResponse response = Business.LoginBusiness.Login(request);
            return response;
        }
    }
}
