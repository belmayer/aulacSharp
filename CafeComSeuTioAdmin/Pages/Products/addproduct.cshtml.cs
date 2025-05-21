using CafeComSeuTioAdmin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.CodeAnalysis;

namespace CafeComSeuTioAdmin.Pages.Products
{
    public class addproductModel : PageModel
    {
        private CafeContext cafeContext;
        private IWebHostEnvironment webEnv;

        [BindProperty]
        public Product newProduct { get; set; }

        public addproductModel(CafeContext context, IWebHostEnvironment webEnv)
        {
            this.cafeContext = context;
            this.webEnv = webEnv;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (newProduct.Upload is not null)
                {
                    newProduct.ImageFileName = newProduct.Upload.FileName;

                    var file = Path.Combine(webEnv.ContentRootPath,
                                "wwwroot/images/menu", newProduct.Upload.FileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await newProduct.Upload.CopyToAsync(fileStream);
                    }
                }

                cafeContext.Add<Product>(newProduct);
                cafeContext.SaveChanges();
            }

            return RedirectToPage("ViewAllProducts", new { id = newProduct.Id });
        }
    }
}
