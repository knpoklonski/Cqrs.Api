using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CqrsApi.DataAccess;
using CqrsApi.DataAccess.Customers.QueryHandlers;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Infrastructure.Queries.Impl;
using CqrsApi.Domain.Shared.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IQueriesDispatcher, QueriesDispatcher>();
            services.AddScoped<IQueryHandlerFactory, QueryHandlerFactory>();
            services.AddTransient<IQueryHandlerAsync<FindByIdQuery<CustomerDetails>, CustomerDetails>, FindByIdCustomerQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<GetManyQuery<Customer>, IEnumerable<Customer>>, GetManyCustomersQueryHandler>();
            services.AddScoped<IDataBaseConnectionProvider, DataBaseConnectionProvider>();
            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(Configuration.GetConnectionString("DefaultConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
