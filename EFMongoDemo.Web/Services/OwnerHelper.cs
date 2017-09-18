using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EFMongoDemo.Core.Models;

namespace EFMongoDemo.Web.Services
{
	public static class OwnerHelper
	{
		public static List<string> GetTypes()
		{
			List<string> result = new List<string>();
			var type = typeof(Owner);
			var owners = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes()) 
				.Where(p => type.IsAssignableFrom(p) && !p.IsInterface && p.IsSubclassOf(type));

			foreach (var owner in owners)
			{
				result.Add(owner.Name);
				//result.Add(owner.GetTypeString());
			}

			return result;
		}

		public static IOwner GetOwner(string ownerType)
		{
			var assemblyName = typeof(IOwner).Assembly.GetName();
			var nameSpace = typeof(IOwner).Namespace;
			Type type = Type.GetType($"{nameSpace}.{ownerType},{assemblyName}"); //target type
			object o = Activator.CreateInstance(type); // an instance of target type
			IOwner result = o as IOwner;

			return result;
		}
	}
}