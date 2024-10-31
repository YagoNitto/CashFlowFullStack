using System.Net.Http.Json;
using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class ReportHandler(IHttpClientFactory httpClientFactory) : IReportHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(
        GetIncomesAndExpensesRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<IncomesAndExpenses>?>>($"/reports/incomes-expenses")
               ?? new Response<List<IncomesAndExpenses>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(
        GetIncomesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<IncomesByCategory>?>>($"/reports/incomes")
               ?? new Response<List<IncomesByCategory>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(
        GetExpensesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<ExpensesByCategory>?>>($"/reports/expenses")
               ?? new Response<List<ExpensesByCategory>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<Response<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<FinancialSummary?>>($"/reports/summary")
               ?? new Response<FinancialSummary?>(null, 400, "Não foi possível obter os dados");
    }
}