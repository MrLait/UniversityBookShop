using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Models;

namespace UniversityBookShop.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

        private void HandleValidationException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            //if (!context.ModelState.IsValid)
            //{
            //    HandleInvalidModelStateException(context);
            //    return;
            //}

            HandleUnknownException(context);
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = ServiceResult.Failed(ServiceError.DefaultError);

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

    }
}
