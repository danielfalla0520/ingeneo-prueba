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

    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult<Model.Response.BookResponse> GetAll()
        {
            Model.Response.BookResponse response = Business.BookBusiness.GetAll();
            return response;
        }
        [HttpPost]
        public ActionResult<Model.Response.BookResponse> GetBookById(Model.Request.BookRequest request)
        {
            Model.Response.BookResponse response = Business.BookBusiness.GetBookById(request);
            return response;
        }
        
    }
}
