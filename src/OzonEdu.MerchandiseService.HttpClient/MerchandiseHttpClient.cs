using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpClient.Interfaces;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetAllResponse>> V1GetMerch(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/merchandise/merch", token);

            var body = await response.Content.ReadAsStringAsync(token);

            return JsonSerializer.Deserialize<List<GetAllResponse>>(body);
        }

        public async Task<MerchResponse> V1GetMerchById(Guid id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merchandise/merch/{id}", token);

            var body = await response.Content.ReadAsStringAsync(token);

            return JsonSerializer.Deserialize<MerchResponse>(body);
        }

        public async Task<MerchInfoResponse> V1GetInfo(Guid id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merchandise/merch?id={id}", token);

            var body = await response.Content.ReadAsStringAsync(token);

            return JsonSerializer.Deserialize<MerchInfoResponse>(body);
        }
    }
}