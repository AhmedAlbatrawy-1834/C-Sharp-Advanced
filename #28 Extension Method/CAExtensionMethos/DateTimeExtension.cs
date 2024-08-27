namespace CAExtensionMethos
{
    public static class DateTimeExtension   
    {
        public static bool IsWeekEnd(this DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Friday) || (dt.DayOfWeek == DayOfWeek.Saturday);
        }
        public static bool IsWorkDay(this DateTime dt)
        {
            return !(IsWeekEnd(dt));
        }
    }
}
