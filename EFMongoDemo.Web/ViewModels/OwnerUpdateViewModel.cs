using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFMongoDemo.Web.ViewModels
{
	public class OwnerUpdateViewModel
	{
		public string OwnerTypeString { get; set; }
		public SelectList OwnerType { get; set; }
		public string OwnerName { get; set; }
	}
}
