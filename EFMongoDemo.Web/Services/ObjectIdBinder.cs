using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;

namespace EFMongoDemo.Web.Services
{
	public class ObjectIdBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var values = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (values.Length == 0) return Task.CompletedTask;

			// Attempt to parse
			var stringValue = values.FirstValue;
			ObjectId id;
			if (ObjectId.TryParse(stringValue, out id))
			{
				bindingContext.ModelState.SetModelValue(bindingContext.ModelName, id, stringValue);
				bindingContext.Result = ModelBindingResult.Success(id);
			}

			return Task.CompletedTask;
		}
	}
}