using EFMongoDemo.Core.Models;
using EFMongoDemo.Web.ViewModels;

namespace EFMongoDemo.Web.Extensions
{
    public static class CarModelExtensions
    {
		public static Car ToModel(this CarViewModel carViewModel)
		{
			var result = new Car
			{
				Model = carViewModel.Model,
				Price = carViewModel.Price,

				Owner = new Employee
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

	    public static Car MapViewModel(this Car car, CarViewModel carViewModel)
	    {
		    car.Model = carViewModel.Model;
		    car.Price = carViewModel.Price;
		    car.Owner.Name = carViewModel.OwnerName;

		    return car;
	    }
	}
}
