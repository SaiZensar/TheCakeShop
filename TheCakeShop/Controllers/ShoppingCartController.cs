using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCakeShop.Models;
using TheCakeShop.ViewModels;

namespace TheCakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingcartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingcartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
