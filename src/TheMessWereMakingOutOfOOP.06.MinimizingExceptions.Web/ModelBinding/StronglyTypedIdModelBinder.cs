using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.ModelBinding
{
    public class StronglyTypedIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var value = valueProviderResult.FirstValue;

            if (StronglyTypedId.TryParse(value, bindingContext.ModelType, out var parsedId))
            {
                bindingContext.Result = ModelBindingResult.Success(parsedId);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}