using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;

namespace DotNet7.BlazorWebApp.WebApi.ResponseModel;

public class Result<T>
{
    public bool Success { get; set; }
    public bool Error => !Success;
    public string Message { get; set; }
    public T Data { get; set; }

    public static Result<T> SuccessResult(T data, string message = "Operation Successful.")
    {
        return new Result<T> { Success = true, Data = data, Message = message };
    }

    public static Result<T> SuccessResult(string message = "Operation Successful.")
    {
        return new Result<T> { Success = true, Message = message };
    }

    public static Result<T> FailureResult(string message = "Operation Fail.")
    {
        return new Result<T> { Success=false, Message = message };
    }

    public static Result<T> FailureResult(object obj)
    {
        JObject jObj = JObject.FromObject(obj);
        return new Result<T>
        {
            Success = jObj["Success"]!.Value<bool>(),
            Message = jObj["Message"]!.ToString()
        };
    }

    public static Result<T> FailureResult(Exception ex)
    {
        return new Result<T> { Success = false, Message = ex.ToString() };
    }

    public static Result<T> ExecuteResult(int result)
    {
        return result > 0 ? SuccessResult() : FailureResult();
    }
}