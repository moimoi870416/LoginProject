namespace LoginTest.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            }

            if (!Enum.TryParse<T>(value, true, out var result))
            {
                throw new ArgumentException($"'{value}' is not a valid value for enum {typeof(T).Name}.");
            }

            return result;
        }
    }
}
