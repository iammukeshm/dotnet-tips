var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentEmail("troy.wintheiser9@ethereal.email")
                .AddRazorRenderer()
                .AddMailKitSender(new FluentEmail.MailKitSmtp.SmtpClientOptions
                {
                    Server = "smtp.ethereal.email",
                    Port = 587,
                    Password = "UXTYJMBKU2Hdr6m53Q",
                    RequiresAuthentication = true,
                    User = "troy.wintheiser9@ethereal.email",
                    SocketOptions = MailKit.Security.SecureSocketOptions.StartTls
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
