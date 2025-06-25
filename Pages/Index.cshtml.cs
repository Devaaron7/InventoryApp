using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InventoryApp.Models;
using InventoryApp.Data;

namespace InventoryApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryRepository _repo;

        public IndexModel(IInventoryRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public string Category { get; set; }

        public List<InventoryItem> InventoryItems { get; set; }

        public void OnGet()
        {
            InventoryItems = _repo.GetItems();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InventoryItems = _repo.GetItems();
                return Page();
            }

            var newItem = new InventoryItem
            {
                Name = Name,
                Quantity = Quantity,
                Category = Category
            };

            _repo.AddItem(newItem);

            return RedirectToPage();
        }
    }
}
