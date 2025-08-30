using EGHeals.Application.Dtos.Stocks;

namespace EGHeals.Application.Features.Stocks.Commands.CreateStock
{
    public record CreateStockCommand(CreateStockDto Stock) : ICommand<CreateStockResult>;
    public record CreateStockResult(Guid Id);

    public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
    {
        public CreateStockCommandValidator()
        {
            RuleFor(x => x.Stock).NotNull().WithMessage("Error")
                                 .SetValidator(new CreateStockDtoValidator());
        }
    }

    public class CreateStockDtoValidator : AbstractValidator<CreateStockDto>
    {
        public CreateStockDtoValidator()
        {
            RuleFor(x => x.StoreId).NotEmpty().WithMessage("Error")
                                   .NotNull().WithMessage("Error");

            RuleFor(x => x.RadiologyItemId).NotEmpty().WithMessage("Error")
                                           .NotNull().WithMessage("Error");

            RuleFor(x => x.Qty).NotEmpty().WithMessage("Error");

            RuleFor(x => x.CriticalQty).NotEmpty().WithMessage("Error")
                                        .LessThan(0).WithMessage("Error");
        }
    }
}
