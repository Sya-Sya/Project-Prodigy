namespace CollegeApp.Domain.Enums;

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