using AutoMapper;
using Books.API.Dtos.Book;
using Books.ApplicationCore.Entities.BookAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class BookResultFilterAttribute : ResultFilterAttribute
    {
        //private readonly ILogger<BookResultFilterAttribute> _logger;

        //public BookResultFilterAttribute(ILoggerFactory loggerFactory)
        //{
        //    _logger = loggerFactory.CreateLogger<BookResultFilterAttribute>();
        //}

        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context, ResultExecutionDelegate next
            )
        {
            var resultFromAction = context.Result as ObjectResult;
            
            if(resultFromAction?.Value == null 
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300
               )
            {
                await next();
                return;
            }
                       
            resultFromAction.Value = Mapper.Map<BookForReturnDto>(resultFromAction.Value);

            await next();
        }
    }
}
