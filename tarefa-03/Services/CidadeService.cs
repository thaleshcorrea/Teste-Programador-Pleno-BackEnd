using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace tarefa_03.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceSettings _options;

        public CidadeService(HttpClient httpClient, IOptions<ServiceSettings> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public record Response(int StatusCode, bool Data);

        public async Task<bool> Exists(Guid idCidade)
        {
            string uri = $@"https://{_options.ApiCidadeHost}/cidades/exists/{idCidade}";
            var response = await _httpClient.GetAsync(uri);
            return response.IsSuccessStatusCode;
        }
    }
}