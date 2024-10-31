using System.Net.Http.Json;
using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("/transactions", request);
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
            ?? new Response<Transaction?>(null, 400, "Não foi possível criar sua transação.");
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"/transactions/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, 400, "Não foi possível atualizar sua transação.");
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"/transactions/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, 400, "Não foi possível excluir sua transação.");
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        return await _client.GetFromJsonAsync<Response<Transaction?>>($"/transactions/{request.Id}")
               ?? new Response<Transaction?>(null, 400, "Não foi possível obter a transação");
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        const string format = "yyyy-MM-dd";
        
        var startDate = request.StartDate is not null 
            ? request.StartDate.Value.ToString(format) 
            : DateTime.Now.GetFirstDay().ToString(format);
        
        var endDate = request.EndDate is not null
            ? request.EndDate.Value.ToString(format)
            : DateTime.Now.GetLastDay().ToString(format);
        
        var url = $"/transactions?startDate={startDate}&endDate={endDate}";

        return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>(url)
            ?? new PagedResponse<List<Transaction>?>(null, 400, "Não foi possível obter as transações.");
    }
}