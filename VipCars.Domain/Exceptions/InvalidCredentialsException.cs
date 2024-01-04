namespace VipCars.Domain.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid email or password")
    {
    }
}