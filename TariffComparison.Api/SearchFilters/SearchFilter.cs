using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TariffComparison.Api.SearchFilters
{
    // Just for referencing implement the Schema filter to assign some default values to the request models.
    public class SearchFilters : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SetDefaultParametersFor(context.Type);
        }

        private IOpenApiAny SetDefaultParametersFor(MemberInfo type) // parameter changed from Type to MemberInfo
        {
            // setting the default values for request model.
            return type.Name switch
            {
                "SearchBy" => new OpenApiObject
                {
                    ["Consumption"] = new OpenApiString("850"),
                    ["MonthPeriods"] = new OpenApiString("12")
                },
                _ => null
            };
        }
    }
}