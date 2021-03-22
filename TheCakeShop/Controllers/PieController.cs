using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCakeShop.Models;
using TheCakeShop.ViewModels;

namespace TheCakeShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        /*public IActionResult Index()
        {
            //ViewBag.currentCategory = "Cheese Cake";
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies;
            piesListViewModel.CurrentCategory = "Cheese Cakes";
            return View(piesListViewModel);
        }*/

        public IActionResult Index(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category).OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory

            });
        }

        public ActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
