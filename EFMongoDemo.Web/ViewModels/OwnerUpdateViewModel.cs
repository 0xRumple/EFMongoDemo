using EFMongoDemo.Web.Models;
using EFMongoDemo.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;

namespace EFMongoDemo.Web.ViewModels
{
	public class OwnerUpdateViewModel
	{
		public ObjectId Id { get; set; }
		public SelectList OwnerType { get; set; }
		public string OwnerName { get; set; }

		public IOwner ToModel()
		{
			var result = OwnerHelper.GetOwner(OwnerType.SelectedValue.ToString());
			result.Name = OwnerName;

			return result;
		}
	}
}
