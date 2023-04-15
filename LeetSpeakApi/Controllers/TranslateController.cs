using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LeetSpeak.Api.Controllers
{
    [ApiController]
    [Route("translate")]
    public class TranslateController : ControllerBase
    {
        #region Properties
        private readonly ITranslateService _translateService;
        #endregion

        private readonly ILogger<TranslateController> _logger;

        public TranslateController(
            ILogger<TranslateController> logger,
            ITranslateService translateService
            )
        {
            _logger = logger;
            _translateService = translateService;
        }

        [HttpGet(Name = "AddTranslation")]
        public IActionResult AddTranslation(string originalText)
        {
            _translateService.AddTranslation(originalText);
            return Ok("");
        }
    }
}