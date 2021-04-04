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
    [Authorize]

    public class AuthorController : Controller
    {
        [HttpGet]
        public ActionResult<Model.Response.AuthorResponse> GetAll()
        {
            Model.Response.AuthorResponse response = Business.AuthorBusiness.GetAll();
            return response;
        }
        [HttpPost]
        public ActionResult<Model.Response.AuthorResponse> GetAuthorById(Model.Request.AuthorRequest request)
        {
            Model.Response.AuthorResponse response = Business.AuthorBusiness.GetAuthorById(request);
            return response;
        }
    }
}
