using Newtonsoft.Json;
using Orange.Data.Repositories.Interfaces;
using Orange.Data.Seeders.Extensions;
using Orange.Data.Seeders.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Orange.Data.Seeders
{
    public class MovieSeeder
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly HttpClient httpClient;

        public MovieSeeder(IMoviesRepository moviesRepository, HttpClient httpClient)
        {
            this.moviesRepository = moviesRepository;
            this.httpClient = httpClient;
        }

        public async Task Seed()
        {
            var dbNotEmpty = (await moviesRepository.GetAll(page: 1, pageSize: 1)).Any();

            if (dbNotEmpty)
            {
                return;
            }
            
            var apiKey = "dad8a59d86a2793dda93aa485f7339c1";
            var apiURL = $"popular?api_key={apiKey}";

            var response = await httpClient.GetAsync(apiURL);
            var result = await response.Content.ReadAsStringAsync();
            var moviesResult = JsonConvert.DeserializeObject<MovieResult>(result);

            foreach (var item in moviesResult.Results)
            {
                await moviesRepository.Add(item.ToEntity());
            }
        }
    }
}
