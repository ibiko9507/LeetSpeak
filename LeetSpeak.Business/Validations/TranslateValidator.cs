using FluentValidation;
using FluentValidation.Results;
using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;

public class TranslateValidator : AbstractValidator<Translation>
{
	private readonly ITranslateRepository _translateRepository;
	//in case we need to do the controlls from database

	public TranslateValidator(ITranslateRepository translate)
	{
		_translateRepository = translate;

		RuleFor(customUrl => customUrl)
			.NotEmpty().WithMessage(UserMessageConstants.TheWordCanNotBeEmpty);
	}
}
