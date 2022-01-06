using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Service;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetbyIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"Couldn't find {id} in the Database.");

                context.Result = new NotFoundObjectResult(errorDto);
            }



        }

    }
}
