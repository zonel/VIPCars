namespace VipCars.Domain.Validation;

public interface ICreateOrderValidation
{
    bool IsDateRangeValid(DateTimeOffset startDate, DateTimeOffset endDate);
    bool IsDateRangeAlreadyTaken(DateTimeOffset startDate, DateTimeOffset endDate, int carId);
}