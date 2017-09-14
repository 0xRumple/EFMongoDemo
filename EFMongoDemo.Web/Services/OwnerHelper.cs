using System;
using System.Collections.Generic;
using System.Linq;
using EFMongoDemo.Core.Models;

namespace EFMongoDemo.Web.Services
{
	public static class OwnerHelper
	{
		public static List<string> GetTypes()
		{
			List<string> result = null;
			var type = typeof(IOwner);
			var owners = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes()) 
				.Where(p => type.IsAssignableFrom(p)) as IEnumerable<IOwner>;

			foreach (var owner in owners)
			{
				result.Add(owner.GetTypeString());
			}

			return result;
		}

		public static IOwner GetOwner(string ownerType)
		{
			Type type = Type.GetType(ownerType); //target type
			object o = Activator.CreateInstance(type); // an instance of target type
			IOwner result = o as IOwner;

			return result;
		}
	}
}