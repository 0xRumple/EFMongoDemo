using System;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace EFMongoDemo.Web.Services
{
	public class MongoDbObjectIdConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object result = null;
			if (CanConvert(objectType))
			{
				result = existingValue.ToString();
			}
			return result;
		}

		public override bool CanConvert(Type objectType) => objectType == typeof(ObjectId);
	}
}