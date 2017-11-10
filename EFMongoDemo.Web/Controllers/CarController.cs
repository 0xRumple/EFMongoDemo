using System.Threading.Tasks;
using EFMongoDemo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Services;
using EFMongoDemo.Web.Extensions;

namespace EFMongoDemo.Web.Controllers
{
	public class CarController : Controller
	{
		private readonly CarRepository _carRepo;

		public CarController(EFMongoDemoDbContext context)
		{
			_carRepo = new CarRepository(context);
		}

		// GET: Cars
		public async Task<IActionResult> Index()
		{
			var cars = await _carRepo.GetAll().ToListAsync();

			//var owner = cars[0].Owner;

			return View(cars);
		}

		// GET: Cars/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var car = await _carRepo.GetById(id);

			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}

		// GET: Cars/Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CarViewModel carViewModel)
		{
			if (ModelState.IsValid)
			{
				var car = carViewModel.ToModel();
				await _carRepo.Add(car);
				return RedirectToAction(nameof(Index));
			}
			return View(carViewModel);
		}

		// GET: Cars/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var car = await _carRepo.GetById(id);
			if (car == null)
			{
				return NotFound();
			}
			return View(car.ToViewModel());
		}

		// POST: Cars/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, CarViewModel carViewModel)
		{
			if (ModelState.IsValid)
			{
				var car = await _carRepo.GetById(id);
				car = car.UpdateFromViewModel(carViewModel);

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
				return RedirectToAction(nameof(Index));
			}

			return View(carViewModel);
		}

		// GET: Cars/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var car = await _carRepo.GetById(id);
			if (car == null)
			{
				return NotFound();
			}

			return View(car.ToViewModel());
		}

		// POST: Cars/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			await _carRepo.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
