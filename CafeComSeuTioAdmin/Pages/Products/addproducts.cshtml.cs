using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CafeComSeuTioAdmin.Pages.Products
{
    public class addproductsModel : PageModel
    {
        [BindProperty]

        public string NomeProduto { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }
}
