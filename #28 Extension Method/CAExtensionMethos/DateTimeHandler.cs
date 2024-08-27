namespace CAExtensionMethos
{
    public static class DateTimeHandler   //Old Style Helper Class
    {
        public static bool IsWeekEnd(DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Friday) || (dt.DayOfWeek == DayOfWeek.Saturday);
        }
        public static bool IsWorkDay(DateTime dt)
        {
            return !(IsWeekEnd(dt));
        }
    }
}
