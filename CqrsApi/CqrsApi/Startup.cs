using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CqrsApi.DataAccess;
using CqrsApi.DataAccess.Customers.CommandHandlers;
using CqrsApi.DataAccess.Customers.QueryHandlers;
using CqrsApi.Domain;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Infrastructure.Commands.Impl;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Infrastructure.Queries.Impl;
using CqrsApi.Domain.Shared.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddScoped<IQueryHandlersFactory, QueryHandlersFactory>();
            services.AddScoped<ICommandHandlersFactory, CommandHandlersFactory>();
            services.AddScoped<ICommandsDispatcher, CommandsDispatcher>();
            services.AddScoped<IDataBaseConnectionProvider, DataBaseConnectionProvider>();
            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(Configuration.GetConnectionString("DefaultConnection"))
            );

            #region Customers
            services.AddTransient<IQueryHandlerAsync<FindByIdQuery<CustomerDetails>, CustomerDetails>, FindByIdCustomerQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<GetManyQuery<Customer>, IEnumerable<Customer>>, GetManyCustomersQueryHandler>();
            services.AddTransient<ICommandHandlerAsync<CreateCustomerCommand>, CreateCustomerHandler>();
            #endregion Customers

            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Version = GetType().Assembly.GetName().Version.ToString(),
                        Title = "CQRS API",
                        Description = string.Join("<br/>", "CQRS API .Net Core 2")
                    });
            });
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS API V1");
                c.DocumentTitle = "CQRS API";
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
