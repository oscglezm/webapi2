using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApi.Models;

namespace webApi.Controllers
{
    public class ContactController : ApiController
    {

        Contact[] contacts = new Contact[]
        {
            new Contact(){Id = 1, FirstName = "Cuquita", LastName = "Matraquilla"}, 
            new Contact(){Id = 2, FirstName = "Pepito", LastName = "paquetico"}, 
            new Contact(){Id = 3, FirstName = "Maydita", LastName = "la gordita"}, 
        };

        // GET api/contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/contact/5
        public IHttpActionResult Get(int id)
        {
            Contact current = contacts.FirstOrDefault<Contact>(c => c.Id == id);

            if (current == null)
                return NotFound();

            return Ok(current);
        }

        // POST api/contact
        public IEnumerable<Contact> Post([FromBody] Contact newContact)
        {
            List<Contact> contactList = contacts.ToList<Contact>();

            newContact.Id = contactList.Count+1;
            contactList.Add(newContact);
            contacts = contactList.ToArray();

            return contacts;
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
