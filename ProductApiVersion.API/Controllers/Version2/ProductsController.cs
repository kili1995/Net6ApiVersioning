namespace ProductApiVersion.API.Controllers.Version2
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using ProductApiVersion.API.Controllers.Version2.Dtos;

    [ApiVersion("2.0")]
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
        [MapToApiVersion("2.0")]
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
