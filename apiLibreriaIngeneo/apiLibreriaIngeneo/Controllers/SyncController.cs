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

    public class SyncController : Controller
    {
        [HttpGet]
        public ActionResult<Model.Response.CodeResponse> SyncWithIngeneoApi()
        {
            Model.Response.CodeResponse response = Business.SyncBusiness.Sync();
            return response;
        }
    }
}
