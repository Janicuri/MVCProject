using Microsoft.AspNetCore.Mvc;
using SnakeApplication.Models;

namespace SnakeApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
       
            private readonly List<Item> _cartItems;

            public ShoppingCartController()
            {
                _cartItems = new List<Item>();
            }

            public IActionResult Index()
            {

                return View(_cartItems);
            }

            [HttpPost]
            public IActionResult AddToCart(Item item)
            {
                _cartItems.Add(item);
                return RedirectToAction("Index");
            }
        }
    }


