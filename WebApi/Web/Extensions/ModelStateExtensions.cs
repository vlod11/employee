using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            //TODO: maybe delete
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}