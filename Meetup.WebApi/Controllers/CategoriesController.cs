using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Meetup.WebApi.Models;

namespace Meetup.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private FIN_iRMS_Dev_ST_6JulyEntities db = new FIN_iRMS_Dev_ST_6JulyEntities();

        // GET: api/Categories
        public IQueryable<HWL_Categories> GetHWL_Categories()
        {
            return db.HWL_Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(HWL_Categories))]
        public IHttpActionResult GetHWL_Categories(int id)
        {
            HWL_Categories hWL_Categories = db.HWL_Categories.Find(id);
            if (hWL_Categories == null)
            {
                return NotFound();
            }

            return Ok(hWL_Categories);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHWL_Categories(int id, HWL_Categories hWL_Categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hWL_Categories.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(hWL_Categories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HWL_CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(HWL_Categories))]
        public IHttpActionResult PostHWL_Categories(HWL_Categories hWL_Categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HWL_Categories.Add(hWL_Categories);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hWL_Categories.CategoryId }, hWL_Categories);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(HWL_Categories))]
        public IHttpActionResult DeleteHWL_Categories(int id)
        {
            HWL_Categories hWL_Categories = db.HWL_Categories.Find(id);
            if (hWL_Categories == null)
            {
                return NotFound();
            }

            db.HWL_Categories.Remove(hWL_Categories);
            db.SaveChanges();

            return Ok(hWL_Categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HWL_CategoriesExists(int id)
        {
            return db.HWL_Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}