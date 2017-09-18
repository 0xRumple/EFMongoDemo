using System;

namespace EFMongoDemo.Web.Services
{
	public class ControllerHelper
	{
		public static string UrlName(string controller)
		{
			if (!controller.EndsWith("Controller")) throw new ArgumentException($"{controller} is an invalid arguement");
			return controller.EndsWith("Controller") ? controller.Substring(0, controller.Length - 10) : controller;
		}
	}
}

