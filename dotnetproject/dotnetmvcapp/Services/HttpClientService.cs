using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace dotnetmvcapp.Services
{
    public interface IHttpClientService{
        public Task<T> Get<T>(string uri);
        public Task<T> Post<T>(string uri,object content);
    }
    public class HttpClientService: IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string baseurl = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io";
        public HttpClientService(IHttpClientFactory httpClientFactory){
            _httpClientFactory = httpClientFactory;
        }


        public async Task<T> Get<T>(string uri){
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"}
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if(httpResponseMessage.IsSuccessStatusCode){
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(contentStream);
            }
            throw new Exception("API Unavailable");
        }

        public async Task<T> Post<T>(string uri,object content){
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"}
                },
                Content = new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json")
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            Console.WriteLine(JsonSerializer.Serialize(httpResponseMessage));

            if(httpResponseMessage.IsSuccessStatusCode){
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var response = await JsonSerializer.DeserializeAsync<T>(contentStream);
                return response;
            }
                using var contentStream1 = await httpResponseMessage.Content.ReadAsStreamAsync();
                var resp = await JsonSerializer.DeserializeAsync<string>(contentStream1);
            throw new Exception(resp);
        }
    }
}