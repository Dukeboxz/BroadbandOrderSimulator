namespace BroadbandSupplierSimulator.Mappers;

internal static class MapperHelpers
{
    public static DateTimeOffset? ToUtc(DateTimeOffset? value)
    {
        return value?.ToUniversalTime();
    }

    public static DateTimeOffset ToUtc(DateTimeOffset value)
    {
        return value.ToUniversalTime();
    }

    public static TTarget ConvertEnum<TTarget>(Enum value) where TTarget : struct, Enum
    {
        return Enum.Parse<TTarget>(value.ToString());
    }

    public static TTarget? ConvertNullableEnum<TTarget>(Enum? value) where TTarget : struct, Enum
    {
        return value is null ? null : Enum.Parse<TTarget>(value.ToString());
    }
}
