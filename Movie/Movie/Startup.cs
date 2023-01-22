using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orange.Api.Services;
using Orange.Api.Services.Interfaces;
using Orange.Data.Context;
using Orange.Data.Repositories;
using Orange.Data.Repositories.Interfaces;
using Orange.Data.Seeders;
using System;
using System.Threading.Tasks;

namespace Orange.Api
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
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IFavoriteService, FavoriteService>();
            services.AddTransient<IFavoritesRepository, FavoritesRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IGenreService, GenreService>();

            services.AddControllers();
            services.AddHttpClient<MovieSeeder>(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3/movie/"));
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = "Movies",
                Description = "Description"
            }));
            var movieSeeder = services.BuildServiceProvider().GetRequiredService<MovieSeeder>();
            movieSeeder.Seed().Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
