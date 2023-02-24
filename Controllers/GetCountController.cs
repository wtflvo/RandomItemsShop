using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomItemsShop.DbConnectors;
using RandomItemsShop.Models;

namespace RandomItemsShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCountController : ControllerBase
    {
        private readonly ILogger<GetCountController> _logger;

        public GetCountController(ILogger<GetCountController> logger)
        {
            _logger = logger;
        }

                
        [HttpPost, Authorize]
        public int GetCount(RequestData request)
        {
            DbReader reader = new DbReader();
            int result = reader.getCountFromDB(request);

            return result;
        }

    }
}

