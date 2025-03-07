﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.ErrorModels
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        internal static ErrorResponse From(Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErrorResponse()
            {
                Code = e.HResult,
                Message = e.Message,
                InnerError = ErrorResponse.From(e.InnerException)
            };
        }

        internal static ErrorResponse From(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(m => m.Errors);

            return new ErrorResponse()
            {
                Code = 100,
                Message = "Houve erro(s) no envio da requisição.",
                Details = errors.Select(e => e.ErrorMessage).ToArray()
            };
        }

        internal static ErrorResponse From(string message)
        {

            return new ErrorResponse()
            {
                Code = 100,
                Message = message,
            };
        }

        internal static object FromModelState(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}
