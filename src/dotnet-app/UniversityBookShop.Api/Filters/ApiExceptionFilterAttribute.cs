﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.ComponentModel.DataAnnotations;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Models;
using ValidationException = UniversityBookShop.Application.Common.Exceptions.ValidationException;

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
                { typeof(MySqlException), HandleMySqlException },
                { typeof(DbUpdateException), HandleDbUpdateException },
            };
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

        private void HandleDbUpdateException(ExceptionContext context)
        {
            if(context.Exception.InnerException is MySqlException mySqlException) 
            {
                context.Exception = mySqlException;
                HandleMySqlException(context);
            }

            if (context.Exception is DbUpdateException exception)
            {
            }
            context.ExceptionHandled = false;
        }

        private void HandleMySqlException(ExceptionContext context)
        {
            if (context.Exception is MySqlException sqlException)
            {
                var exceptionMessage = sqlException.Message;
                var statusCode = sqlException.Number;
                var details = ServiceResult.Failed(ServiceError.CustomMessage(exceptionMessage, statusCode));
                context.Result = new NotFoundObjectResult(details);
                context.ExceptionHandled = true;
                return;
            }
            context.ExceptionHandled = false;

        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

        private void HandleValidationException(ExceptionContext context)
        {
            if(context.Exception is ValidationException exception)
            {
                var details = ServiceResult.Failed(exception.Errors, ServiceError.Validation);
                context.Result = new BadRequestObjectResult(details);
            }

            context.ExceptionHandled = true;
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
