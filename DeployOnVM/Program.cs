using DeployOnVM.Services;
using Microsoft.FeatureManagement;

namespace DeployOnVM
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var conString = "Endpoint=https://azureappconfiggmf.azconfig.io;Id=JfhD;Secret=sML70L+VStHYPXjdSCBK+r+LrmRsA4ptkhf3rxAn7+E=";
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            builder.Host.ConfigureAppConfiguration(builder =>
            {
                //builder.AddAzureAppConfiguration(conString);
				builder.AddAzureAppConfiguration(option =>
				{
					option.Connect(conString).UseFeatureFlags();
				});//If you want to use feature flag
            });


			


            builder.Services.AddTransient<IProductService, ProductService>();

			builder.Services.AddFeatureManagement();//To Enable Feature Management Service

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}