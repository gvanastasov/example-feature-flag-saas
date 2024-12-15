using ExampleFeatureFlagService.Api.Interfaces;
using ExampleFeatureFlagService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleFeatureFlagService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlagsController : ControllerBase
{
    private readonly IFeatureFlagService _service;

    public FlagsController(IFeatureFlagService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeatureFlag>>> GetFlags()
    {
        var flags = await _service.GetAllAsync();
        return Ok(flags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FeatureFlag>> GetFlag(int id)
    {
        var flag = await _service.GetByIdAsync(id);
        if (flag == null) return NotFound();

        return Ok(flag);
    }

    [HttpPost]
    public async Task<ActionResult<FeatureFlag>> CreateFlag(FeatureFlag flag)
    {
        var createdFlag = await _service.CreateAsync(flag);
        return CreatedAtAction(nameof(GetFlag), new { id = createdFlag.Id }, createdFlag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFlag(int id, FeatureFlag flag)
    {
        if (id != flag.Id) return BadRequest();

        var updatedFlag = await _service.UpdateAsync(flag);
        if (updatedFlag == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlag(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}