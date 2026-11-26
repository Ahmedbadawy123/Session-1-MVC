using MVCDemo01.Middlewares;

namespace MVCDemo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // MVC

            //builder.Services.AddControllers(); // API

            //builder.Services.AddRazorPages(); // Razor Pages

            var app = builder.Build();

            #region Middleware Pipeline

            // Any Use is Middleware.

            // Configure the HTTP request pipeline.
            // 1- Put Exception Handling Middleware First to catch any exception in the pipeline.
            // 2- Put Then UseHsts To Tell The Browser to Use HTTPS for Future Requests.
            // 3- Put Then UseHttpsRedirection to Redirect HTTP Requests to HTTPS.
            // 4- Sometimes Put UseStaticFiles to Serve public Assets / Files [WWWROOT]
            // 5- Put Then UseRouting to Match the Incoming URL With The Available Endpoints/Actions.
            // 6- Sometimes Put UseCors to Allow Cross-Origin Requests. (With Frontend Onlyyyy)
            // 7- Put Then UseAuthentication to Authenticate the User. (Who Are You?)
            // 8- Sometimes Put UseSession to Store User Data in Session. (For Authenticated Users) , and Enable The App to Read and Write Session Data.
            // 9- Put Then UseAuthorization to Authorize the User. (Are You Allowed to Do This?)
      
            app.UseMiddleware<RequestTimingMiddleWare>();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); // Hsts -> HTTP STRICT TRANSPORT SECURITY.
            }

            app.UseHttpsRedirection();

            //app.UseStaticFiles(); 

            app.UseRouting();

            //app.UseCors(); // Cors -> Cross-Origin Resource Sharing. (To Talk With Frontend Onlyyyy)

            //app.UseAuthentication(); 

            #region Inline Middleware [Custom Middleware]

            //app.Use(async (context, next) =>
            //{
            //    // Before next() [Request]
            //    Console.WriteLine($"Hello");
            //    // next()
            //    await next(context);
            //    // After next() [Response]
            //    Console.WriteLine($"Bye");
            //});

            #endregion

            //app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}") // Routing Pattern (Default Route)
                .WithStaticAssets();

            app.Run(); // Last Middleware in the Pipeline. (The Terminal Middleware) (Dead Code).
            #endregion

        }
    }
}
