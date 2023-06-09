using FluentAssertions;
using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared.Models;
using LeetSpeak.Test.Mocks;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeetSpeak.Test
{
	[TestFixture]
	public class TranslateServiceTests
	{
		private ITranslateRepository _translateRepository;
		private TranslateValidator _translateValidator;
		private ITranslationFactory _translationFactory;
		private TranslateService _translateService; [SetUp]
		public void SetUp()
		{
			_translateRepository = new MockTranslateRepository();
			_translateValidator = new TranslateValidator(new MockTranslateRepository());
			_translationFactory = new MockTranslationFactory();
			_translateService = new TranslateService(_translateRepository, _translateValidator, _translationFactory);
		}

		[Test]
		public async Task ConvertOriginalTextToFormattedText_ShouldSendHttpRequest()
		{
			// Arrange
			var inputText = "hello world";
			var expectedResponse = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent("some response message")
			};
			var httpClient = new HttpClient(new MockHttpMessageHandler(request =>
			{
				return Task.FromResult(expectedResponse);
			}));

			// Act
			var result = await _translateService.ConvertOriginalTextToFormattedText(inputText);

			// Assert
			Assert.False(result.HasError);
			Assert.AreNotEqual(inputText, result.ResponseMessage);
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




