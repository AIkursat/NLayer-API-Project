using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerProject.API.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NLayerProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context) // When request comes to action, intervent it.
        {

            if (!context.ModelState.IsValid) // In case of entering Missing or wrong propoerty such as Name, stock etc...
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                modelErrors.ToList().ForEach(x =>
               {
                   errorDto.Errors.Add(x.ErrorMessage); // It will fiil our List which name is Errors.
               });

                context.Result = new BadRequestObjectResult(errorDto);


            };
        }

    }
}
