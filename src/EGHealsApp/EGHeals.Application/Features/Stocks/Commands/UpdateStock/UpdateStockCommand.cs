using EGHeals.Application.Dtos.Stocks;

namespace EGHeals.Application.Features.Stocks.Commands.UpdateStock
{
    public record UpdateStockCommand(UpdateStockDto Stock) : ICommand<UpdateStockResult>;
    public record UpdateStockResult(bool IsSuccess);

    public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(x => x.Stock).NotNull().WithMessage("Error")
                                 .SetValidator(new UpdateStockDtoValidator());
        }
    }

    public class UpdateStockDtoValidator : AbstractValidator<UpdateStockDto>
    {
        public UpdateStockDtoValidator()
        {
            RuleFor(x => x.Qty).NotEmpty().WithMessage("Error");

            RuleFor(x => x.CriticalQty).NotEmpty().WithMessage("Error")
                                        .LessThan(0).WithMessage("Error");
        }
    }
}
