using CashFlowInputs.API.Application.DTOs;
using CashFlowInputs.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowInputs.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CashFlowInputsController : ControllerBase
{
    private readonly ICashFlowInputService _cashFlowInputService;

    public CashFlowInputsController(
        ICashFlowInputService cashFlowInputService)
    {
        _cashFlowInputService = cashFlowInputService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("create")]
    public async Task<ActionResult<CashFlowInputDto>> Create([FromBody] CashFlowInputDto dto)
    {
        try
        {
            var cashFlowInput = await _cashFlowInputService.CreateCashFlowInputAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cashFlowInput.Id }, cashFlowInput);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("update")]
    public async Task<ActionResult<CashFlowInputDto>> Update([FromBody] CashFlowInputDto dto)
    {
        try
        {
            var updatedCashFlowInput = await _cashFlowInputService.UpdateCashFlowInputAsync(dto);
            return Ok(updatedCashFlowInput);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _cashFlowInputService.DeleteCashFlowInputAsync(id);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("getById")]
    public async Task<ActionResult<CashFlowInputDto>> GetById(long id)
    {
        try
        {
            var cashFlowInputs = await _cashFlowInputService.GetCashFlowInputByIdAsync(id);
            return Ok(cashFlowInputs);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}