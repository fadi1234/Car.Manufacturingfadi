using Car.Manufacturing.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Manufacturing.EF.Repositories
{
    public class ApiRepository : IApiRepository
    {
        public async Task<string> GetURL(Uri Url)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(Url);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }
    }
}
