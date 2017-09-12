using EFMongoDemo.Web.Models;

namespace EFMongoDemo.Web.ViewModels
{
    public class CarViewModel
    {
		public string Model { get; set; }
	    public int Price { get; set; }
	    public string OwnerName { get; set; }

	    public Car ToModel()
	    {
		    var result = new Car
		    {
				Model = Model,
				Price = Price,
				Owner = new Employee
				{
					Name = OwnerName
				}
		    };

		    return result;
	    }
	}
}
