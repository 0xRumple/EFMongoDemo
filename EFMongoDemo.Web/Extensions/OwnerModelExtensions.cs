using EFMongoDemo.Core.Models;
using EFMongoDemo.Web.Services;
using EFMongoDemo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFMongoDemo.Web.Extensions
{
    public static class OwnerModelExtensions
    {
		//public static IOwner ToModel(this OwnerUpdateViewModel ownerUpdateViewModel)
		//{
		//	var result = OwnerHelper.GetOwner(ownerUpdateViewModel.OwnerTypeString);
		//	result.Name = ownerUpdateViewModel.OwnerName;

		//	return result;
		//}

	    public static OwnerUpdateViewModel ToViewModel(this IOwner owner)
	    {
		    var result = new OwnerUpdateViewModel
		    {
			    OwnerName = owner.Name,
			    OwnerType = new SelectList(OwnerHelper.GetTypes())
			};

			return result;
	    }

	    public static IOwner MapViewModel(this IOwner owner, OwnerUpdateViewModel ownerUpdateViewModel)
	    {
			var newOwnerType = OwnerHelper.GetOwner(ownerUpdateViewModel.OwnerTypeString);
		    if (newOwnerType.GetType() != owner.GetType())
		    {
			    var tempOwner = owner;
			    owner = newOwnerType;
			    owner.Id = tempOwner.Id;
		    }
			owner.Name = ownerUpdateViewModel.OwnerName;

		    return owner;
	    }
	}
}
