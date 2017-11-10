using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMongoDemo.Data.Services
{
	public class CarRepository : DataService<Car, string>
	{
		public CarRepository(EFMongoDemoDbContext context) : base(context)
		{
		}

		//public override IQueryable<Car> GetAll()
		//{
		//	//var result = await (
		//	//		from car in DbSet
		//	//		join owner in Context.Owners on car.OwnerId equals owner.Id
		//	//		select new Car
		//	//		{
		//	//			Id = car.Id,
		//	//			Model = car.Model,
		//	//			Price = car.Price,
		//	//			OwnerId = car.OwnerId,
		//	//			Owner = owner
		//	//		}).ToListAsync();

		//	//var result = await DbSet.Join(Context.Owners,
		//	//						myCar => myCar.Id,
		//	//						owner => owner.Id,
		//	//						(car, owner) => new Car
		//	//						{
		//	//							Id = car.Id,
		//	//							Model = car.Model,
		//	//							Price = car.Price,
		//	//							OwnerId = car.OwnerId,
		//	//							Owner = owner
		//	//						}).ToListAsync();

		//	var result = DbSet

		//	return result;
		//}

		public override async Task<Car> Add(Car car)
		{
			var owner = car.Owner;
			var ownerRepo = new OwnerRepository(Context);
			await ownerRepo.Add(owner);
			//car.OwnerId = owner.Id;

			return await base.Add(car);
		}

		//public override async Task<Car> GetById(string id)
		//{
		//	var result = await (
		//		from car in DbSet
		//		where car.Id == id
		//		join owner in Context.Owners on car.OwnerId equals owner.Id
		//		select new Car
		//		{
		//			Id = car.Id,
		//			Model = car.Model,
		//			Price = car.Price,
		//			OwnerId = car.OwnerId,
		//			Owner = owner
		//		}).SingleOrDefaultAsync();

		//	return result;
		//}
	}
}
