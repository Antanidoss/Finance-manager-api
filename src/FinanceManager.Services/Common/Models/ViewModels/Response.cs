using FinanceManager.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels
{
    public class Response<D>
    {
        public D Data { get; set; }
        public Result Result { get; set; }
        public Response(D data, Result result)
        {
            Data = data;
            Result = result;
        }
    }
}
