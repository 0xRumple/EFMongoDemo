//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using MongoDB.Bson;
//using EFMongoDemo.Core.Models;
//using EFMongoDemo.Data;

//namespace EFMongoDemo.Web.Controllers
//{
//    public class OwnerController : Controller
//    {
//	    private readonly EFMongoDemoDbContext _context;

//	    public OwnerController(EFMongoDemoDbContext context)
//		{ 
//		    _context = context;
//	    }
//		public async Task<IActionResult> Add(ObjectId id)
//		{
//			//var objectId = new ObjectId(id);
//			//var car = await _context.Cars.SingleOrDefaultAsync(m => m.Model == "Puegotoo");
//			var car = await _context.Cars.SingleOrDefaultAsync(m => m.Id == id);
//			if (car == null)
//			{
//				return NotFound("Invalid car id!");
//			}

//			return View();
//		}

//	    public async Task<IActionResult> Update(ObjectId id)
//	    {
//		    //var objectId = new ObjectId(id);
//		    var car = await _context.Cars.SingleOrDefaultAsync(m => m.Id == id);
//		    if (car == null)
//		    {
//			    return NotFound("Invalid car id!");
//		    }

//		    return View();
//	    }

//		[HttpPost]
//	    public async Task<IActionResult> Add(ObjectId carId, [Bind("Id,Name")] Employee employee)
//	    {
//		    if (ModelState.IsValid)
//		    {
//			    var car = await _context.Cars.SingleOrDefaultAsync(m => m.Id == carId);
//				//car.Owners.Add(owner);
//				//car.Owner = owner;

//			    try
//				{
//				    _context.Update(car);
//				    await _context.SaveChangesAsync();
//			    }
//			    catch (DbUpdateConcurrencyException)
//			    {
//				    throw;
//			    }
//			    return RedirectToAction(nameof(Index), "Cars");
//		    }
//			return View(employee);
//		}
//	}
//}