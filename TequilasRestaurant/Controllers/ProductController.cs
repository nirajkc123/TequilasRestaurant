using Microsoft.AspNetCore.Mvc;
using TequilasRestaurant.Data;
using TequilasRestaurant.Models;

namespace TequilasRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;
        private Repository<Ingredient> ingredients;
        private Repository<Category> categories;

        public ProductController(ApplicationDbContext context)
        {
            products = new Repository<Product>(context);
            ingredients = new Repository<Ingredient>(context);
            categories = new Repository<Category>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Ingredients = await ingredients.GetAllAync();
            ViewBag.Categories = await categories.GetAllAync();
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Product());

            }
            else
            {
                ViewBag.Operation = "Edit";
                return View();
            }


        }

    }
}
