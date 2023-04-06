using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.BLL.Service;
using MaterialsManagement.DAL.DbContext;
using MaterialsManagement.DAL.Interfaces;
using MaterialsManagement.DAL.Repository;


namespace MaterialsManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Section));

            builder.Services.AddSingleton<MaterialsDbContext>();
            // Customer
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            // Material
            builder.Services.AddScoped<IMaterialService, MaterialService>();
            builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();

            //Order

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"));

            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(b => b.AllowAnyOrigin()
                            .AllowAnyHeader());
          
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}