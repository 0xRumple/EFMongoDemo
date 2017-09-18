using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Services;
using EFMongoDemo.Web.Extensions;
using EFMongoDemo.Web.Services;
using EFMongoDemo.Web.ViewModels;

namespace EFMongoDemo.Web.Controllers
{
	public class OwnerController : Controller
	{
		private readonly CarRepository _carRepo;

		public OwnerController(EFMongoDemoDbContext context)
		{
			_carRepo = new CarRepository(context);
		}

		//public async Task<IActionResult> Add(string id)
		//{
		//	var car = await _carRepo.GetById(id);
		//	if (car == null)
		//	{
		//		return NotFound("Invalid car id!");
		//	}

		//	return View();
		//}

		//[HttpPost]
		//public async Task<IActionResult> Add(string id, [Bind("Id,Name")] Employee employee)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var car = await _carRepo.GetById(id);
		//		//car.Owners.Add(owner);
		//		//car.Owner = owner;

		//		try
		//		{
		//			await _carRepo.Update(car);
		//		}
		//		catch (DbUpdateConcurrencyException)
		//		{
		//			throw;
		//		}
		//		return RedirectToAction(nameof(Index), "Cars");
		//	}
		//	return View(employee);
		//}

		public async Task<IActionResult> Update(string id)
		{
			var car = await _carRepo.GetById(id);
			if (car == null)
			{
				return NotFound("Invalid car id!");
			}

			var ownerUpdateViewModel = car.Owner.ToViewModel();

			return View(ownerUpdateViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Update(string id, OwnerUpdateViewModel ownerUpdateViewModel)
		{
			if (ModelState.IsValid)
			{
				var car = await _carRepo.GetById(id);
				car.Owner = car.Owner.MapViewModel(ownerUpdateViewModel);

				try
				{
					await _carRepo.Update(car);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await _carRepo.EntityExists(car.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index), ControllerHelper.UrlName(nameof(CarsController)));
			}

			return View(ownerUpdateViewModel);
		}
	}
}