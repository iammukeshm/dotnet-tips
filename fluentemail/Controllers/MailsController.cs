using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;

namespace fluentemail.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailsController : ControllerBase
{
    private readonly IFluentEmail _fluentEmail;
    public MailsController(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }
    [HttpPost]
    public async Task<IActionResult> SendEmailAsync()
    {
        var email = await _fluentEmail
                    .To("hellomukesh@gmail.com", "Mukesh")
                    .Subject("Hey Mukesh!")
                    .Body("Hey, long time no see!")
                    .SendAsync();
        return Ok(email);
    }

    [HttpPost("template")]
    public async Task<IActionResult> SendTemplatedEmailAsync()
    {
        _fluentEmail.Renderer = new FluentEmail.Razor.RazorRenderer();
        const string template = "Dear @Model.Name, You User ID is @Model.Id.";
        var email = await _fluentEmail
                    .To("hellomukesh@gmail.com", "Mukesh")
                    .Subject("Hey Mukesh!")
                    .UsingTemplate(template, new { Name = "Mukesh", Id = "1994" })
                    .SendAsync();
        return Ok(email);
    }
}
