using AutoMapper;
using Books.API.Dtos.Book;
using Books.ApplicationCore.Entities.BookAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class BooksResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300
               )
            {
                await next();
                return;
            }

            resultFromAction.Value = Mapper.Map<IEnumerable<BookForReturnDto>>(resultFromAction.Value);

            await next();
        }
    }
}

