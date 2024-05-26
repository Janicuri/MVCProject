using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SnakeApplication.Data;
using SnakeApplication.Models;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace SnakeApplication.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        string[] colors = { "red", "green", "blue", "yellow", "purple", "orange", "white", "pink" };
        public GameController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = User;
            var userId = _userManager.GetUserId(user);
            //Debug.WriteLine(userId);
            var player = await _context.Players.Where(p => p.IdentityUserId == userId).ToListAsync();
            return View(player[0]);
        }
        [HttpPost]
        public async Task<string> UpdateScore(int score)
        {
            try
            {
                var user = User;
                var userId = _userManager.GetUserId(user);
                var player = await _context.Players.Where(p => p.IdentityUserId == userId).ToListAsync();
                if (score > player[0].Score)
                {
                    player[0].Score = score;
                }
                _context.Update(player[0]);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return "Error! Could not update score";
            }
            return "Score Updated";
        }
        private bool ValidColor(string s)
        {
            foreach (string c in colors)
            {
                if (c == s.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public IActionResult Fail()
        {
            return View();
        }
        public IActionResult Sukses()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ViewColor v)
        {
            string color = v.c;
            Debug.WriteLine(color);
            if (string.IsNullOrEmpty(color))
            {
                return RedirectToAction("Fail");
            }

            Debug.WriteLine("WORKING");
            bool valid = ValidColor(color);
            if (valid)
            {
                var user = User;
                var userId = _userManager.GetUserId(user);
                var player = await _context.Players.Where(p => p.IdentityUserId == userId).FirstOrDefaultAsync();
                if (player != null)
                {
                    player.Color = color;
                    _context.Update(player);
                    await _context.SaveChangesAsync();

                    // Set the color preference in a cookie
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7),
                        Secure = true
                    };
                    Response.Cookies.Append("ColorPreference", color, options);

                    return RedirectToAction("Sukses");
                }
            }

            return RedirectToAction("Fail");
        }

   
    
    [AllowAnonymous]
        public async Task<IActionResult> Leaderboard()
        {
            var lista = await _context.Players.OrderByDescending(p => p.Score).ToListAsync();

            return View(lista);
        }
        
 
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = User;
            var userId = _userManager.GetUserId(user);
            var playerId = await _context.Players.Where(p =>p.IdentityUserId == userId).ToListAsync();
            var playerPurchases = await _context.purchases.Where(e => e.PlayerId == playerId[0].Id).ToListAsync();
            List<int> purchasesItemsIds = playerPurchases.Select(p => p.ItemId).ToList();
            var playerItems = await _context.items.Where(e => purchasesItemsIds.Contains(e.Id)).ToListAsync();
            PlayerProfile p = new PlayerProfile
            {
                player = playerId[0],
                items = playerItems
            };

            return View(p);
        }

        [HttpPost]
        
        public async Task<string> Equip(int ItemId)
        {
            try
            {
                var user = User;
                var UserId = _userManager.GetUserId(user);
                var playerId = await _context.Players.Where(e => e.IdentityUserId == UserId).ToListAsync();
                var item = await _context.items.Where(i => i.Id == ItemId).ToListAsync();
                Player p = playerId[0];
                p.CurrentItemUrl = item[0].ImageUrl;
                _context.Update(p);
                _context.SaveChanges();
                return "Success";
            }
            catch (Exception ex) { 
                return ex.Message;
            }
        }

    }
}
