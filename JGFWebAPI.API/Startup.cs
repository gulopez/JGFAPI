using JGFWebAPI.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using JGFWebAPI.Models.Mapping;
using JGFWebAPI.Bussiness.Bussiness;

namespace JGFWebAPI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connstr = Configuration.GetConnectionString("App1");
            services.AddDbContext<FortoulContext>(options => options.UseSqlServer(connstr));
            services.AddTransient(typeof(UsuarioBussiness), typeof(UsuarioBussiness));
            services.AddTransient(typeof(PerfilBussiness), typeof(PerfilBussiness));
            services.AddTransient(typeof(RepresentanteBussiness), typeof(RepresentanteBussiness));
            services.AddTransient(typeof(AlumnoBussiness), typeof(AlumnoBussiness));
            services.AddTransient(typeof(GradoEscolarBussiness), typeof(GradoEscolarBussiness));
            services.AddTransient(typeof(PeriodoEscolarBussiness), typeof(PeriodoEscolarBussiness));
            services.AddTransient(typeof(PreInscripcionBussiness), typeof(PreInscripcionBussiness));
            services.AddTransient(typeof(PaisBussiness), typeof(PaisBussiness));
            services.AddTransient(typeof(EstadoProvinciaBussiness), typeof(EstadoProvinciaBussiness));
            services.AddTransient(typeof(EstadoCivilBussiness), typeof(EstadoCivilBussiness));
            services.AddTransient(typeof(FormaDePagoBussiness), typeof(FormaDePagoBussiness));
            services.AddTransient(typeof(PagoBussiness), typeof(PagoBussiness));
            services.AddTransient(typeof(SolicitudCupoBussiness), typeof(SolicitudCupoBussiness));
            services.AddTransient(typeof(DireccionBussiness), typeof(DireccionBussiness));
            services.AddTransient(typeof(DatoFamiliarBussiness), typeof(DatoFamiliarBussiness));
            services.AddTransient(typeof(DatoMedicoBussiness), typeof(DatoMedicoBussiness));
            services.AddTransient(typeof(EstadoBussiness), typeof(EstadoBussiness));
            services.AddTransient(typeof(CarritoCompraBussiness), typeof(CarritoCompraBussiness));
            services.AddTransient(typeof(MesEscolarBussiness), typeof(MesEscolarBussiness));
            services.AddTransient(typeof(ConceptoPagoBussiness), typeof(ConceptoPagoBussiness));
            services.AddTransient(typeof(PagoDetalladoBussiness), typeof(PagoDetalladoBussiness));
            services.AddTransient(typeof(SeccionBussiness), typeof(SeccionBussiness));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ApiJGF", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "API JGF",
                    Version = "1.0",
                    Description = "Backend de consulta a la BD"
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeader",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/ApiJGF/swagger.json", "API JGF");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAllHeaders");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
