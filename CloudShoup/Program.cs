using CloudShoup.Controller;
using CloudShoup.Models;
using CloudShoup.Models.Entity;
using CloudShoup.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShoupDbContext>();

//builder.Services.AddScoped<OrderController>();
builder.Services.AddTransient<IOrderService,CRUDService>();

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/get", async (HttpContext context, IOrderService service) =>
{
    await context.Response.WriteAsJsonAsync(service.GetAllOrders());
});
app.MapPost("/add", async (HttpContext context, IOrderService service) =>
{
    Order neworder = await context.Request.ReadFromJsonAsync<Order>();
    service.AddOrder(neworder);
    await context.Response.WriteAsJsonAsync(neworder);
});
app.MapPost("/delete", async (HttpContext context, IOrderService service) =>
{
    int id = Convert.ToInt32(context.Request.Form["id"]) ;
    service.RemoveOrderById(id);
    await context.Response.WriteAsync("Order deleted");
});
app.Run();
