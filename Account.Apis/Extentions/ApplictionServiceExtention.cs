using Account.Apis.Errors;
using Account.Core.IServices.Content;
using Account.Core.Services.Content;
using Account.Reposatory.Services.Content;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Extentions
{
    public static class ApplictionServiceExtention
    {
        public static IServiceCollection AddAplictionService(this IServiceCollection service)
        {
            // Configure API behavior options
            service.Configure<ApiBehaviorOptions>(Options =>
            {
                // Customize the behavior for handling invalid model state
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    // Extract validation errors from the ModelState
                    var Errors = actionContext.ModelState
                        .Where(P => P.Value.Errors.Count() > 0)
                        .SelectMany(P => P.Value.Errors)
                        .Select(E => E.ErrorMessage)
                        .ToArray();

                    // Create a response object with validation errors
                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = Errors
                    };

                    // Return a BadRequestObjectResult with the validation error response
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });
            service.AddAutoMapper(typeof(MappingProfile));


            //service.AddScoped<IFileService, FileService>();
            service.AddScoped<IJobService, JobService>();
            service.AddScoped<IPropertyService, PropertyService>();
            service.AddScoped<IFileService, FileService>();


            return service;
        }
    }
}
