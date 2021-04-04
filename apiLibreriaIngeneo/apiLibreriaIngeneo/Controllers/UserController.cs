using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiLibreriaIngeneo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult<Model.Response.UserResponse> Create(Model.Request.UserRequest request)
        {
            Model.Response.UserResponse response = Business.UserBusiness.Create(request);
            return response;
        }
    }
}
