using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var CustomerModel = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(CustomerModel);
        }
        
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var CustomerList = _context.Customers.Include(c => c.MembershipType).ToList();
            
            if (id > CustomerList.Count || id == 0 )
                return HttpNotFound();
            else
            {
                var customer = CustomerList.ElementAt(id - 1);
                return View(customer) ;
            }
            
        }
    }
}