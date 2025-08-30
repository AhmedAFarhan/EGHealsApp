namespace EGHeals.Application.Dtos.Stocks;
public record CreateStockDto(Guid RadiologyItemId, Guid StoreId, decimal Qty, decimal CriticalQty);