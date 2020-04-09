using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using MovieRank.Libs.Repository;
using MovieRank.Services;

namespace MovieRank
{
   public class Startup
   {
      public Startup (IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices (IServiceCollection services)
      {
         // Environment.SetEnvironmentVariable ("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
         // Environment.SetEnvironmentVariable ("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
         //Environment.SetEnvironmentVariable ("AWS_REGION", Configuration["AWS:Region"]);

         services.AddControllersWithViews ();
         services.AddMvc ();

         services.AddAWSService<IAmazonDynamoDB> ();
         services.AddDefaultAWSOptions (
            new AWSOptions
            {
               Region = RegionEndpoint.GetBySystemName ("us-east-1")
            }
         );

         services.AddSingleton<IMovieRankService, MovieRankService> ();
         services.AddSingleton<IMovieRankRepository, MovieRankRepository> ();
         services.AddSingleton<IMapper, Mapper> ();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment ())
         {
            app.UseDeveloperExceptionPage ();
         }
         else
         {
            app.UseExceptionHandler ("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
         }
         //app.UseHttpsRedirection();
         app.UseStaticFiles ();

         //app.UseMvc ();

         app.UseRouting ();

         //app.UseAuthorization();

         app.UseEndpoints (endpoints =>
         {
            endpoints.MapControllerRoute (
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}
