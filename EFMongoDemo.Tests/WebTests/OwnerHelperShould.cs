using System.Reflection;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Web.Services;
using Xunit;

namespace EFMongoDemo.Tests.WebTests
{
	public class OwnerHelperShould
	{
		[Fact]
		public void GetAllInterfaces()
		{
			var ownersDerivedTypes = OwnerHelper.GetTypes();

			Assert.Equal(ownersDerivedTypes.Count, 2);
		}

		[Fact]
		public void CreateInstanceByName()
		{
			var typeString = "Employee";
			var employee = OwnerHelper.GetOwner(typeString);

			Assert.Equal(employee.GetType(), typeof(Employee));
		}
	}
}
