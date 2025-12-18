using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Services;

using WebShopApp.Infrastructure.Data.Entities;


namespace WebShopApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        private string GetUserId() => _userManager.GetUserId(User);

        // GET: CartController
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            return View(cart);
        }

        public async Task<IActionResult> Add(int productId)
        {
            var userId = GetUserId();
            await _cartService.AddItemAsync(userId, productId);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(int productId)
        {
            var userId = GetUserId();
            await _cartService.RemoveItemAsync(userId, productId);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> IncreaseQuantity(int productId)
        {
            var userId = GetUserId();
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                await _cartService.UpdateQuantityAsync(userId, productId, item.Quantity + 1);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DecreaseQuantity(int productId)
        {
            var userId = GetUserId();
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                await _cartService.UpdateQuantityAsync(userId, productId, item.Quantity - 1);
            }
            if (item.Quantity <= 0)
            {
                cart.Items.Remove(item);
            }
            return RedirectToAction("Index");
        }



        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
