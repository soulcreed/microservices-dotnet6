using Microsoft.AspNetCore.Authentication;
using Shopp.Web.Services;
using Shopp.Web.Services.IServices;

namespace Shopp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient<IProductService, ProductService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:ProductApi"]));
            builder.Services.AddHttpClient<ICartService, CartService>(c =>
                    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CartAPI"]));
            builder.Services.AddHttpClient<ICouponService, CouponService>(c =>
                    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CouponAPI"]));

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "shopps";
                    options.ClientSecret = "my_super_secret";
                    options.ResponseType = "code";
                    options.ClaimActions.MapJsonKey("role", "role", "role");
                    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("shopps");
                    options.SaveTokens = true;
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}