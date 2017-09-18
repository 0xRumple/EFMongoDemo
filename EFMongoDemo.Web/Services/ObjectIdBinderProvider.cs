using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;

namespace EFMongoDemo.Web.Services
{
	public class ObjectIdBinderProvider : IModelBinderProvider
	{
		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			return context.Metadata.ModelType == typeof(ObjectId) ? new ObjectIdBinder() : null;
		}
	}
}