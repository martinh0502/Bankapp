using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bankapp.Data.EFModels;
using Bankapp.Core.Interfaces;
using Bankapp.Core.Services;
using Bankapp.Data.Interfaces;
using Bankapp.Data.Repos;

namespace Bankapp
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bankapp", Version = "v1" });
            });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanRepo, LoanRepo>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IDispositionService, DispositionService>();
            services.AddScoped<IDispositionRepo, DispositionRepo>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IAccountTypeRepo, AccounTypeRepo>();

            services.AddDbContext<BankAppDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bankapp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
