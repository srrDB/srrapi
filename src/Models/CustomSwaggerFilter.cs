using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace srrapi.Models
{
    public class CustomSwaggerFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var nonMobileRoutes = swaggerDoc.Paths.Where(x => !x.Key.StartsWith("/api")).ToList();

            nonMobileRoutes.ForEach(x =>
            {
                swaggerDoc.Paths.Remove(x.Key);
            });
        }
    }
}
