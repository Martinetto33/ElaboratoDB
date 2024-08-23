namespace DatabaseProject.common
{
    public static class Utils
    {
        public static string MapMillisToTime(long millis)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(millis);
            return 0L <= millis ? time.ToString(@"mm\:ss") : "00:00";
        }
    }
}
