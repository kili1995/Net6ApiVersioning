using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductApiVersion.API.Controllers.Version1.Dtos;

namespace ProductApiVersion.API.Controllers.Version1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string FakeApiStoreURL = $"https://fakestoreapi.com/products";
        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var apiResult = await _httpClient.GetStringAsync(FakeApiStoreURL);
                var products = JsonConvert.DeserializeObject<List<Product>>(apiResult);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
