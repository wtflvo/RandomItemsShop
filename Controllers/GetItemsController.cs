using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomItemsShop.DbConnectors;
using RandomItemsShop.Models;


namespace RandomItemsShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetItemsController : ControllerBase
    {

        
        private readonly ILogger<GetItemsController> _logger;

        public GetItemsController(ILogger<GetItemsController> logger)
        {
            _logger = logger;
        }

        [HttpPost, Authorize]
        public List<ShopTable> SendData(RequestData request)
        {
            DbReader reader = new DbReader();
            var result = reader.getItemsFromDB(request);
            
            
            return result;
        }

    }
}