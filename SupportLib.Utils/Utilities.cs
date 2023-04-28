namespace SupportLib.Utils
{
    public static class Utilities
    {
        public static T EnumFrom<T>(int value) where T : IConvertible
        {
            if (!Enum.IsDefined(typeof(T), value))
                throw new ArgumentException($"Enum value {value} not defined!", nameof(value));

            return (T)(object)value;
        }

        public static T? NullableEnumFrom<T>(int value) where T : struct
        {
            if (!Enum.IsDefined(typeof(T), value))
                return null;

            return (T)(object)value;
        }
    }
}
