using Microsoft.AspNetCore.Mvc;
using LeetSpeak.Shared.Models;

namespace LeetSpeak.Api
{
    public static class UrlShorteningResponseHelper
    {
        public static async Task<IActionResult> GenerateResponse(this Task<LeetSpeakResponse> result)
        {
            LeetSpeakResponse response = await result;

            if (response.HasError)
            {
                return new BadRequestObjectResult(response);
            }

            return new JsonResult(response);
        }
    }
}
