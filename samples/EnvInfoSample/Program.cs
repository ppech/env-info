using DotVVM.Framework.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using EnvInfo.Razor;

namespace EnvInfoSample
{
	public static class Program
    {
        public static async Task Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDataProtection();
			builder.Services.AddAuthorization();
			builder.Services.AddWebEncoders();
			builder.Services.AddAuthentication();

			builder.Services.AddEnvInfo("CUSTOM");

			builder.Services.AddDotVVM<DotvvmStartup>();

			builder.Services.AddRazorPages();
			builder.Services.AddRazorComponents();
			builder.Services.AddServerSideBlazor();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
				app.UseHttpsRedirection();
				app.UseHsts();
			}

			app.UseWebAssemblyDebugging();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseBlazorFrameworkFiles();
			app.UseBlazorEnvInfo();
			app.UseStaticFiles();

			app.MapRazorPages();

			// use DotVVM
			var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(builder.Environment.ContentRootPath);
			dotvvmConfiguration.AssertConfigurationIsValid();
			app.UseDotvvmHotReload();

			app.MapBlazorHub();
			app.MapFallbackToFile("index.html");

			await app.RunAsync();
		}
    }
}
