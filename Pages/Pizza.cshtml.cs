using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using asp_webapp_crud.Models;
using asp_webapp_crud.Services;

namespace asp_webapp_crud.Pages
{
    public class PizzaModel : PageModel
    {
        public List<Pizza> pizzas = new();

        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}
