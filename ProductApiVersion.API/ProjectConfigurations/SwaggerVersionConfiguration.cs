namespace ProductApiVersion.API.ProjectConfigurations
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class SwaggerVersionConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionProvider;
        public SwaggerVersionConfiguration(IApiVersionDescriptionProvider apiVersionProvider)
        {
            _apiVersionProvider = apiVersionProvider;
        }      


        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in _apiVersionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Product Versioning TEST API",
                Version = description.ApiVersion.ToString(),
                Description = "API Created for OPEN BootCamp Angular Course",
                Contact = new OpenApiContact()
                {
                    Email = "jorgecapello1995@gmail.com",
                    Name = "Jorge Capello",
                    Url = new Uri($"https://www.linkedin.com/in/jorgecapello1995")
                }
            };

            if (description.IsDeprecated)
            {
                info.Title += $" This version is Deprecated.";
            }

            return info;
        }
    }
}
