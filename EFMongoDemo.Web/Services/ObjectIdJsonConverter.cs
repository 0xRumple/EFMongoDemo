using System;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace EFMongoDemo.Web.Services
{
	public class ObjectIdJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
			//JToken t = JToken.FromObject(value);
			//if (t.Type != JTokenType.Object)
			//{
			//	t.WriteTo(writer);
			//}
			//else
			//{
			//	JObject o = (JObject)t;
			//	IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

			//	o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

			//	o.WriteTo(writer);
			//}
		}


		// source: https://stackoverflow.com/questions/42328212/create-a-custom-model-binder-for-a-custom-type
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var stringValue = reader.Value?.ToString();
			ObjectId result;
			if (ObjectId.TryParse(stringValue, out result))
			{
				return result;
			}
			return null;
		}

		public override bool CanConvert(Type objectType) => objectType == typeof(ObjectId);
	}
}