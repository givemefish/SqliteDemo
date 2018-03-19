// =================================================================
// File: BaseController.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/16 上午 09:50
// Update Date: 2018/03/16 上午 09:54
// =================================================================
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SqliteApi.Common;

namespace SqliteDemo.Controllers
{
    public class BaseController: Controller
    {
        public UnprocessableObjectResult Unprocessable(ModelStateDictionary modelState)
        {
            return new UnprocessableObjectResult(modelState);
        }
    }
}