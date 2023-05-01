using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Admin> emp_list = new List<Admin>();

            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi"); 
            var response = client.GetAsync("CrudApi"); 
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Admin>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);  
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin ad)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.PostAsJsonAsync<Admin>("CrudApi",ad);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }
        public ActionResult Details(int ID)
        {
            Admin a=null;
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.GetAsync("CrudApi?ID="+ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Admin>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        public ActionResult Edit(int ID)
        {
            Admin a = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.GetAsync("CrudApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Admin>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Admin e)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.PutAsJsonAsync<Admin>("CrudApi", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }
        public ActionResult Delete(int ID)
        {
            Admin a = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.GetAsync("CrudApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Admin>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/"+ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");

            
        }
    }
}