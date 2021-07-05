using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ModelView;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer> {

                new Customer {Id = 1 , Name = "John Smith"},
                new Customer {Id = 2 , Name = "Mary Williams"}
        };

        // GET: Customers
        public ActionResult Index()
        {

            var modelView = new CustomersModelView { Customers = customers };
            return View(modelView);
        }
        
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            
            if (id > customers.Count || id == 0 )
                return HttpNotFound();
            else
            {
                var customer = customers.ElementAt(id-1);
                return View(customer) ;
            }
            
        }
    }
}