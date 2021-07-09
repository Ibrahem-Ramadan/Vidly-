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

        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel{

                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerinDb.Name = customer.Name;
                customerinDb.BirthDate = customer.BirthDate;
                customerinDb.IsSubscribedtoNewsLetter = customer.IsSubscribedtoNewsLetter;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm",customerViewModel);
        }
    }
}