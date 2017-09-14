using EFMongoDemo.Core.Models;
using EFMongoDemo.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFMongoDemo.Web.ViewModels
{
	public class OwnerUpdateViewModel
	{
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
