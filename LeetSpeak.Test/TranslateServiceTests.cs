using FluentAssertions;
using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared.Models;
using LeetSpeak.Test.Mocks;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LeetSpeak.Test
{
	[TestFixture]
	public class TranslateServiceTests
	{
		private ITranslateRepository _translateRepository;
		private TranslateValidator _translateValidator;
		private ITranslationFactory _translationFactory;
		private TranslateService _translateService;

		[SetUp]
		public void SetUp()
		{
			_translateRepository = new MockTranslateRepository();
			_translateValidator = new TranslateValidator(new MockTranslateRepository());
			_translationFactory = new MockTranslationFactory();
			_translateService = new TranslateService(_translateRepository, _translateValidator, _translationFactory);
		}

		[Test]
		public async Task ConvertOriginalTextToFormattedText_WhenValidInput_ReturnsCorrectResponse()
		{
			// Arrange
			var input = "hello world";
			var expected = new LeetSpeakResponse
			{
				ResponseMessage = "h3110 w0r1d",
				HasError = false
			};

			// Act
			var result = await _translateService.ConvertOriginalTextToFormattedText(input);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[Test]
		public async Task ConvertOriginalTextToFormattedText_WhenInvalidInput_ReturnsErrorResponse()
		{
			// Arrange
			var input = "";
			var expected = new LeetSpeakResponse
			{
				ResponseMessage = "'Original Text' must not be empty.",
				HasError = true
			};

			// Act
			var result = await _translateService.ConvertOriginalTextToFormattedText(input);

			// Assert
			result.Should().BeEquivalentTo(expected);
		}

		[Test]
		public async Task GetTranslations_ReturnsCorrectResponse()
		{
			// Arrange
			var expected = new LeetSpeakResponse
			{
				ResponseMessage = "Translation 1: hello world => h3110 w0r1d\nTranslation 2: goodbye => 900dby3\n",
				HasError = false
			};

			// Act
			var result = await _translateService.GetTranslations();

			// Assert
			result.Should().BeEquivalentTo(expected);
		}
	}
}
