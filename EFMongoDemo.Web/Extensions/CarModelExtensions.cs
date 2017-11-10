using EFMongoDemo.Core.Models;
using EFMongoDemo.Web.ViewModels;

namespace EFMongoDemo.Web.Extensions
{
    public static class CarModelExtensions
    {
		// TODO: delete similar logic from ToModel and use UpdateFromViewModel function
		public static Car ToModel(this CarViewModel carViewModel)
		{
			var result = new Car
			{
				Model = carViewModel.Model,
				Price = carViewModel.Price,

				Owner = new Owner
				{
					Name = carViewModel.OwnerName
				}
			};

			return result;
		}

	    public static CarViewModel ToViewModel(this Car car)
	    {
		    var result = new CarViewModel
		    {
			    Model = car.Model,
			    Price = car.Price,
				OwnerName = car.Owner.Name
			};

		    return result;
	    }

	    public static Car UpdateFromViewModel(this Car car, CarViewModel carViewModel)
	    {
		    car.Model = carViewModel.Model;
		    car.Price = carViewModel.Price;
		    car.Owner.Name = carViewModel.OwnerName;

		    return car;
	    }
	}
}
