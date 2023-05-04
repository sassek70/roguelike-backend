var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((options) => 
{
    options.AddPolicy("DevCors", (corsBuilder) => 
        {
            /* 
                Setting CORS policy for development

                default localhost ports:
                    Angular.JS - 4200
                    React.JS - 3000
                    Vue.JS - 8000
            */ 
            corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });

        options.AddPolicy("ProdCors", (corsBuilder) => 
            {
                /* 
                    Setting CORS policy for product, this gets modified to match production url & needs.

                    default localhost ports:
                        Angular.JS - 4200
                        React.JS - 3000
                        Vue.JS - 8000
                */ 
                corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
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
