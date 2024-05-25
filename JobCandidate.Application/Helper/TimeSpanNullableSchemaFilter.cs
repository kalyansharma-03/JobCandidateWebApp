using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Application.Helper
{
    public class TimeSpanNullableSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TimeSpan?))
            {
                schema.OneOf = new[]
                {
                new OpenApiSchema
                {
                    Type = "string",
                    Format = "hh:mm:ss",
                    Nullable = false
                },
                new OpenApiSchema
                {
                    Type = "null",
                    Nullable = true
                }
            };

            }
        }
    }
}
