using CashFlowReport.API.Application.DTOs;
using CashFlowReport.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowReport.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CashFlowReportController : ControllerBase
{
    private readonly ICashFlowReportService _cashFlowInputService;

    public CashFlowReportController(
        ICashFlowReportService cashFlowInputService)
    {
        _cashFlowInputService = cashFlowInputService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("getByDateRange")]
    public async Task<ActionResult<IEnumerable<CashFlowInputDto>>> GetByDate([FromQuery] DateTime startDate = default, [FromQuery] DateTime endDate = default)
    {
        try
        {
            var cashFlowInputs = await _cashFlowInputService.GetCashFlowReportAsync(startDate, endDate);
            return Ok(cashFlowInputs);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}