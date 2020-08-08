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
    public class UsersController : ApiController
    {
        private FIN_iRMS_Dev_ST_6JulyEntities db = new FIN_iRMS_Dev_ST_6JulyEntities();

        // GET: api/Users
        public IQueryable<HWL_Users> GetHWL_Users()
        {
            return db.HWL_Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(HWL_Users))]
        public IHttpActionResult GetHWL_Users(int id)
        {
            HWL_Users hWL_Users = db.HWL_Users.Find(id);
            if (hWL_Users == null)
            {
                return NotFound();
            }

            return Ok(hWL_Users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHWL_Users(int id, HWL_Users hWL_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hWL_Users.UserId)
            {
                return BadRequest();
            }

            db.Entry(hWL_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HWL_UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(HWL_Users))]
        public IHttpActionResult PostHWL_Users(HWL_Users hWL_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HWL_Users.Add(hWL_Users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hWL_Users.UserId }, hWL_Users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(HWL_Users))]
        public IHttpActionResult DeleteHWL_Users(int id)
        {
            HWL_Users hWL_Users = db.HWL_Users.Find(id);
            if (hWL_Users == null)
            {
                return NotFound();
            }

            db.HWL_Users.Remove(hWL_Users);
            db.SaveChanges();

            return Ok(hWL_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HWL_UsersExists(int id)
        {
            return db.HWL_Users.Count(e => e.UserId == id) > 0;
        }
    }
}