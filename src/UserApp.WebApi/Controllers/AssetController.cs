using UserApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApp.Service.DTOs.Assets;
using UserApp.Service.Services.Assets;

namespace UserApp.WebApi.Controllers;

public class AssetController(IAssetService assetService) : Controller
{
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.GetByIdAsync(id)
        });
    }

    [HttpPost("{id:long}/pictures/upload")]
    public async ValueTask<IActionResult> PictureUploadAsync(AssetCreateModel asset)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await assetService.UploadAsync(asset)
        });
    }
}
