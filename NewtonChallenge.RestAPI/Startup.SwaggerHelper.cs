using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace NewtonChallenge.RestAPI
{
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public class RemoveVersionFromParameter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (!operation.Parameters.Any())
                    return;

                var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ReplaceVersionWithExactValueInPath : IDocumentFilter
        {
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var paths = new OpenApiPaths();

                foreach (var (key, value) in swaggerDoc.Paths)
                    paths.Add(key.Replace("v{version}", swaggerDoc.Info.Version), value);

                swaggerDoc.Paths = paths;
            }
        }

        /// <summary>
        /// Needs Microsoft.AspNetCore.Mvc.Versioning package installed
        /// </summary>
        /// <param name="options"></param>
        private static void configureSwaggerGen(SwaggerGenOptions options)
        {
            addSwaggerDocs(options);

            options.OperationFilter<RemoveVersionFromParameter>();
            options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

            options.DocInclusionPredicate((version, desc) =>
            {
                if (!desc.TryGetMethodInfo(out var methodInfo))
                    return false;

                var versions = methodInfo
                   .DeclaringType?
               .GetCustomAttributes(true)
               .OfType<ApiVersionAttribute>()
               .SelectMany(attr => attr.Versions);

                var maps = methodInfo
                   .GetCustomAttributes(true)
               .OfType<MapToApiVersionAttribute>()
               .SelectMany(attr => attr.Versions)
               .ToList();

                return versions?.Any(v => $"v{v}" == version) == true
                         && (!maps.Any() || maps.Any(v => $"v{v}" == version));
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        private static void addSwaggerDocs(SwaggerGenOptions options)
        {
            var name = "Syed Daniyal Haider";
            var email = "DaniyalSHaider@gmail.com";
            var title = "NewtonChallenge.RestAPI";
            var description = "APIs for NewtonChallenge project";

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = title,
                Description = description,
                Contact = new OpenApiContact
                {
                    Name = name,
                    Email = email
                }
            });

            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = title,
                Description = description,
                Contact = new OpenApiContact
                {
                    Name = name,
                    Email = email
                }
            });
        }
    }
}
