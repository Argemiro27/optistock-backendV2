using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaVendasDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IDistribuidoraRepository, DistribuidoraRepository>();
            builder.Services.AddScoped<IItensNFeRepository, ItensNFeRepository>();
            builder.Services.AddScoped<INFeRepository, NFeRepository>();
            builder.Services.AddScoped<IProdutoVendaRepository, ProdutoVendaRepository>();
            builder.Services.AddScoped<IVendaRepository, VendaRepository>();
            builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
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
        }
    }
}