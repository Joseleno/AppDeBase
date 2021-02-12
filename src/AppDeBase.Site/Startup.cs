using AppDeBase.Affaires.Interfaces;
using AppDeBase.Donnees.Context;
using AppDeBase.Donnees.Repository;
using AppDeBase.Extensions;
using AppDeBase.Site.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AppDeBase.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppDeBaseDbContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(o =>
            {
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "La valeur saisie n'est pas valide pour ce champ.");
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Ce champ doit être rempli.");
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Ce champ doit être rempli.");
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "La valeur saisie n'est pas valide pour ce champ.");
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "La valeur saisie n'est pas valide pour ce champ.");
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "Le champ doit être numérique.");
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "La valeur saisie n'est pas valide pour ce champ.");
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "La valeur saisie n'est pas valide pour ce champ.");
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "Le champ doit être numérique.");
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Ce champ doit être rempli.");
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<AppDeBaseDbContext>();
            services.AddScoped<IFournisseurRepository, FournisseurRepository>();
            services.AddScoped<IAdresseRepository, AdresseRepository>();
            services.AddScoped<IProduitRepository, ProduitRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, DeviseValidationAttributeAdapterProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            var defaultCulture = new CultureInfo("fr-CA");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}