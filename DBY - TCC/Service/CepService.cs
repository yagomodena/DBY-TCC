using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DBY___TCC.Service
{
    public class CepService
    {
        private const string ViaCepBaseUrl = "https://viacep.com.br/ws/";

        private readonly HttpClient _httpClient;

        public CepService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ConsultarCepAsync(string cep)
        {
            try
            {
                string url = $"{ViaCepBaseUrl}{cep}/json/";
                var response = await _httpClient.GetStringAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Erro ao buscar o CEP.", ex);
            }
        }
    }
}
