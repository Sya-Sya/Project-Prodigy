namespace CollegeApp.Domain.Enums.Books;

public enum Edition
{
    None,
    Signed,
    Limited,
    First,
    Collector,
    Authors,
    Deluxe = 1 << 5
}