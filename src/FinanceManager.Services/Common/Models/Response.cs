using FinanceManager.Application.Common.Models;

namespace FinanceManager.Services.Common.Models.ViewModels
{
    public class Response<T>
    {
        public T Data { get; set; }
        public Result Result { get; set; }

        public Response(T data, Result result)
        {
            Data = data;
            Result = result;
        }
    }
}
