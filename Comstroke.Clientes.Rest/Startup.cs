using Comstroke.$ext_safeprojectname$.BusinessEngine.Ejecucion.CanalInterno.Clientes;
using Comstroke.$ext_safeprojectname$.BusinessEngine.Ejecucion.CanalInterno.Cuentas;
using Comstroke.$ext_safeprojectname$.BusinessEngine.Ejecucion.CanalInterno.Movimientos;
using Comstroke.Global.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Comstroke.$ext_safeprojectname$.Model.Entidad.Transaccional;
using Comstroke.$ext_safeprojectname$.Model.Transaccion.Response.Transaccionalidad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Comstroke.$ext_safeprojectname$.BusinessEngine.Ejecucion.CanalInterno.Autorizaciones;
using Microsoft.AspNetCore.Http;

namespace $safeprojectname$
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


            services.AddCors(options => options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()  
                )
            );

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                // Other configs...
                o.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        // Call this to skip the default logic and avoid using the default response
                        context.HandleResponse();

                        // Write to the response in any way you wish
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Unauthorized");
                    }
                };
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

       
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Comstoke.Clientes.Rest", Version = "v1" });
            });
 

            services.AddScoped<IRecover<ClienteTransaccion, ClienteResponse>,ConsultarClienteBP>();
            services.AddScoped<IInsert<ClienteTransaccion, ClienteResponse>, EnrolarClienteBP>();
            services.AddScoped<IUpdate<ClienteTransaccion, ClienteResponse>, ActualizarClienteBP>();

            services.AddScoped<IInsert<CuentaTransaccion, CuentaResponse>, EnrolarCuentaBP>();
            services.AddScoped<IRecover<CuentaTransaccion, CuentaResponse>, ConsultarCuentaBP>();
            services.AddScoped<IUpdate<CuentaTransaccion, CuentaResponse>, ActualizarCuentaBP>();

            services.AddScoped<IInsert<MovimientoTransaccion, MovimientoResponse>, RegistrarMovimientoBP>();
            services.AddScoped<IRecover<MovimientoTransaccion, MovimientoResponse>, ConsultarMovimientoBP>();
            services.AddScoped<IUpdate<MovimientoTransaccion, MovimientoResponse>, ActualizarMovimientoBP>();
            services.AddScoped<IRecover<MovimientoFechaTransaccion, MovimientoFechaResponse>, ConsultarMovimientoFechaBP>();

            services.AddScoped<IRecover<ClaveTransaccion, ClaveResponse>, ClaveBP>();

            //container.RegisterType(typeof(IObtener<,>), typeof(ConsultarClientePR), "ConsultarClientePR", new ContainerControlledLifetimeManager());

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core.Clientes.Rest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
