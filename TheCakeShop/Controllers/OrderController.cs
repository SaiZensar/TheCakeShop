using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCakeShop.Models;

namespace TheCakeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart is Empty, Add Pies first and place order");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.Createorder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order, Enjoy the Delicious Pies";
            return View();
        }
    }
}
