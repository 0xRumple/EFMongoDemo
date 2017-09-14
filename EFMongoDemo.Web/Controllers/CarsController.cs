using System.Threading.Tasks;
using EFMongoDemo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Extensions;
using EFMongoDemo.Data.Services;

namespace EFMongoDemo.Web.Controllers
{
    public class CarsController : Controller
    {
	    private readonly CarsRepository _carRepo;

	    public CarsController(EFMongoDemoDbContext context)
        {
			_carRepo = new CarsRepository(context);
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
			var cars = await _carRepo.GetAll();

	        //var owner = cars[0].Owner;

			return View(cars);
			//return View(await _context.Cars.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(ObjectId id)
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

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        public async Task<IActionResult> Edit(ObjectId id)
        {
	        var car = await _carRepo.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObjectId id, CarViewModel carViewModel)
        {
            //if (id != car.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
	            var car = carViewModel.ToModel();
	            car.Id = car.Id.Create(id);

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
        public async Task<IActionResult> Delete(ObjectId id)
        {
	        var car = await _carRepo.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ObjectId id)
        {
	        await _carRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
