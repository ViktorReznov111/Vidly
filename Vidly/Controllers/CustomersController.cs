using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    [Authorize]
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
        //
        // GET: /Customers/
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(a => a.MembershipType).ToList();


            //return View(customers);
            return View();

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(a => a.MembershipType).SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewmodel = new NewCustomerViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
               {
                   Customer = customer,
                   MembershipTypes=_context.MembershipTypes.ToList()
               };
                return View("CustomerForm",viewModel);

            }

            if (customer.id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);

                // Automapper kullansaydık : Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = (DateTime)customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewslettar = customer.IsSubscribedToNewslettar;


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null) return HttpNotFound();


            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }

    }
}