using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudApiController : ApiController
    {
        khizdbEntities db = new khizdbEntities();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Admin> list = db.Admins.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad= db.Admins.Where(model => model.ID == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Admin e)
        {

            db.Admins.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Admin e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad=db.Admins.Where(model => model.ID == e.ID).FirstOrDefault(); 
            if (ad != null)
            {
                ad.ID = e.ID;
                ad.Name= e.Name;
                ad.Phone=e.Phone;
                ad.Email=e.Email;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete]

        public IHttpActionResult EmpDelete(int ID)
        {
            var ad = db.Admins.Where(model => model.ID == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
