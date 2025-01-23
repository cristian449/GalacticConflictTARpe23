using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Models.Email;
using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailServices;
        public EmailsController(IEmailsServices emailsServices)
        {
            _emailServices = emailsServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult SendTokenEmail(EmailViewModel viewModel, string token)
        {
            var dto = new EmailTokenDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
                Token = token
            };
            _emailServices.SendEmailToken(dto, token);
            return RedirectToAction(nameof(Index));
        }
    }
}
