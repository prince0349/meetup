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
    public class UserCategoriesController : ApiController
    {
        private FIN_iRMS_Dev_ST_6JulyEntities db = new FIN_iRMS_Dev_ST_6JulyEntities();

        // GET: api/UserCategories
        public IQueryable<HWL_UserCategories> GetHWL_UserCategories()
        {
            return db.HWL_UserCategories;
        }

        // GET: api/UserCategories/5
        [ResponseType(typeof(HWL_UserCategories))]
        public IHttpActionResult GetHWL_UserCategories(int id)
        {
            HWL_UserCategories hWL_UserCategories = db.HWL_UserCategories.Find(id);
            if (hWL_UserCategories == null)
            {
                return NotFound();
            }

            return Ok(hWL_UserCategories);
        }

        // PUT: api/UserCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHWL_UserCategories(int id, HWL_UserCategories hWL_UserCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hWL_UserCategories.UserCategoryId)
            {
                return BadRequest();
            }

            db.Entry(hWL_UserCategories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HWL_UserCategoriesExists(id))
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

        // POST: api/UserCategories
        [ResponseType(typeof(HWL_UserCategories))]
        public IHttpActionResult PostHWL_UserCategories(HWL_UserCategories hWL_UserCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HWL_UserCategories.Add(hWL_UserCategories);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hWL_UserCategories.UserCategoryId }, hWL_UserCategories);
        }

        // DELETE: api/UserCategories/5
        [ResponseType(typeof(HWL_UserCategories))]
        public IHttpActionResult DeleteHWL_UserCategories(int id)
        {
            HWL_UserCategories hWL_UserCategories = db.HWL_UserCategories.Find(id);
            if (hWL_UserCategories == null)
            {
                return NotFound();
            }

            db.HWL_UserCategories.Remove(hWL_UserCategories);
            db.SaveChanges();

            return Ok(hWL_UserCategories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HWL_UserCategoriesExists(int id)
        {
            return db.HWL_UserCategories.Count(e => e.UserCategoryId == id) > 0;
        }
    }
}