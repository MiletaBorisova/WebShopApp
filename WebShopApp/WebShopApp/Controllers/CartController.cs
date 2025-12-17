using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.Core.Contracts;
using WebShopApp.Core.Services;
using WebShopApp.Extensions;
using WebShopApp.Models.Cart;

namespace WebShopApp.Controllers
{
   
    public class CartController : Controller
    {
        private const string CartKey = "cart";
        private readonly IProductService  _productService;
        
        private readonly IOrderService _orderService;

        public CartController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }



        // GET: CartController
        public ActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<CartVM>(CartKey) ?? new CartVM();
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound($"Product with ID {productId} not found");
            }

            var cart = HttpContext.Session.GetObject<CartVM>(CartKey) ?? new CartVM();

            var item = cart.Items.FirstOrDefault(x => x.Id == productId);

            decimal discountedPrice = product.Price * (1 - product.Discount / 100m);

            if (item == null)
            {
                cart.Items.Add(new CartItemVM
                {
                    Id = productId,
                    ProductName = product.ProductName,
                    Picture = product.Picture,
                    Price = product.Price * (1 - product.Discount / 100m),
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            HttpContext.Session.SetObject(CartKey, cart);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var cart = HttpContext.Session.GetObject<CartVM>(CartKey);
            var item = cart?.Items.FirstOrDefault(x => x.Id == productId);

            if (item != null)
            {
                cart.Items.Remove(item);
                HttpContext.Session.SetObject(CartKey, cart);
            }

            return RedirectToAction("Index");
        }
        public IActionResult IncreaseQuantity(int productId)
        {
            var cart = HttpContext.Session.GetObject<CartVM>(CartKey);
            var item = cart?.Items.FirstOrDefault(x => x.Id == productId);

            if (item != null)
            {
                item.Quantity++;
                HttpContext.Session.SetObject(CartKey, cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseQuantity(int productId)
        {
            var cart = HttpContext.Session.GetObject<CartVM>(CartKey);
            var item = cart?.Items.FirstOrDefault(x => x.Id == productId);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    cart.Items.Remove(item); // Ако количеството стане 0, премахваме продукта
                }

                HttpContext.Session.SetObject(CartKey, cart);
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
