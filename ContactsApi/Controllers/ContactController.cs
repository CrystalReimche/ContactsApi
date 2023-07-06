using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactsAPIDbContext _dbContext;

        public ContactController(ContactsAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var allContacts = await _dbContext.Contacts.ToListAsync();
            return Ok(allContacts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contact);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactDto addContactDto)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactDto.Address,
                Email = addContactDto.Email,
                FullName = addContactDto.FullName,
                Phone = addContactDto.Phone
            };

            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, ContactDto updateContactDto)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null) 
            {
                contact.FullName = updateContactDto.FullName;
                contact.Phone = updateContactDto.Phone;
                contact.Email = updateContactDto.Email;
                contact.Address = updateContactDto.Address;

                await _dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return Ok(contact);
            }
        }
    }
}
