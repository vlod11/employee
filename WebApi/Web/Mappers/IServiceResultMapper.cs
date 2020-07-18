using Core;
using Microsoft.AspNetCore.Mvc;

namespace Web.Mappers
{
    public interface IServiceResultMapper
    {
        ContentResult ServiceResultToContentResult<T>(ServiceResult<T> result);
    }
}