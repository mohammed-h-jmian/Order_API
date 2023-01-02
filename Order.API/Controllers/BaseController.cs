using Microsoft.AspNetCore.Mvc;
using Order.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(true, "Done", data);
            return response;
        }

    }
}
