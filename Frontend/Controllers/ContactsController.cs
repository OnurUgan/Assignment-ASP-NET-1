using Frontend.Models.DTO;
using Frontend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ContactsController : Controller
    {

        private readonly ContactsService _contactsService;

        public ContactsController(ContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Send(MessageModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _contactsService.CreateMessage(model);

            return RedirectToAction("Index", "Home");

        }






    }
}