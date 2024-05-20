using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeApplication.Data;
using SnakeApplication.Models;

namespace SnakeApplication.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(ApplicationDbContext context, UserManager<IdentityUser> u)
        {
            _context = context;
            _userManager = u;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var items = await _context.items.ToListAsync();
            return View(items);
        }
        [Authorize]
        [HttpPost]

        public async Task<string> Purchase(int id)
        {

            var player = await _context.players.Where(e => e.IdentityUserId == _userManager.GetUserId(User)).ToListAsync();
            var purchaseList = await _context.purchases.Where(e => e.ItemId == id && e.PlayerId == player[0].Id).ToListAsync();
            if (purchaseList.Count > 0)
                return "You have bought this item already";
            else
            {
                Purchase purchase = new Purchase
                {
                    PlayerId = player[0].Id,
                    ItemId = id
                };
                await _context.AddAsync(purchase);
                await _context.SaveChangesAsync();
                return subtractBucks(player[0], id)?"Success":"Inssuficent funds";

            }
          
        }
        private  bool subtractBucks(Player p, int itemId)
        {
            var item =  _context.items.Where(e => e.Id == itemId).ToList();
            if (item[0].Price <= p.Bucks)
            {
                p.Bucks -= (int)item[0].Price;
                _context.Update(p);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}


