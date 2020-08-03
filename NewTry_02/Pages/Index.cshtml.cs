using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NewTry_02.Model;
using NewTry_02.Repository;
//using live_search_ajax_jquery_core.pages.Models;



namespace NewTry_02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository product;

          public IEnumerable<Product> MyProducts { get;  }


        public IndexModel(IProductRepository product)
        {
            this.product = product;
            //GetProducts();
        }

        public void OnGet()
        {

        }

        //[HttpGet]
        //public IActionResult OnGetProducts()
        //{
        //    return OkResult(product.GetAllProducts());
        //}
        
        //public List<Product> OnGetProducts()
        //{
        //    return product.GetAllProducts();
        //}

        public JsonResult OnGetProducts()
        {
            return new JsonResult(product.GetAllProducts());
        }

        private IActionResult OkResult(List<Product> lists)
        {
            throw new NotImplementedException();
        }
    }
}
//https://www.talkingdotnet.com/handle-ajax-requests-in-asp-net-core-razor-pages/
//    https://www.youtube.com/watch?v=AS-IDZIqRQ4&t=650s
//    https://www.youtube.com/watch?v=JmyxrZRr3Hw&t=963s
//    https://www.youtube.com/watch?v=dHiETzo6GB8&t=740s
//https://exceptionnotfound.net/using-named-handler-methods-to-make-jquery-ajax-calls-in-razor-pages/