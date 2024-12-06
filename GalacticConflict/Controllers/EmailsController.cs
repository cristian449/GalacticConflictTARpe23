﻿using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Models.Email;
using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailsServices;
        public EmailsController(IEmailsServices emailsServices)
        {
            _emailsServices = emailsServices;
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
            _emailsServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
