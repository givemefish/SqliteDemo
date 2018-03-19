// =================================================================
// File: UnprocessableObjectResult.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/16 上午 09:51
// Update Date: 2018/03/16 上午 09:52
// =================================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SqliteApi.Common
{
    public class UnprocessableObjectResult: ObjectResult
    {
        public UnprocessableObjectResult(object value): base(value)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public UnprocessableObjectResult(ModelStateDictionary modelState): this(new SerializableError(modelState))
        {
        }
    }
}