using FluentValidation;

namespace Services.Api.DependencyInjection
{
    public interface IValidationProvider
    {
        IValidator<T> GetValidator<T>();
    }
}
