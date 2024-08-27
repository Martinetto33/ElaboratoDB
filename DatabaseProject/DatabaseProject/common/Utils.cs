namespace DatabaseProject.common
{
    public static class Utils
    {
        public static string MapMillisToTime(long millis)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(millis);
            return 0L <= millis ? time.ToString(@"mm\:ss") : "00:00";
        }

        public static long MapTimeToMillis(string time)
        {
            string[] split = time.Split(':');
            return long.Parse(split[0]) * 60000 + long.Parse(split[1]) * 1000;
        }

        public static long GetMillisFromFloatTimeInMinutes(float time)
        {
            double minutes = Math.Floor(time);
            double seconds = (time - minutes) * 60;
            return (long)(minutes * 60000 + seconds * 1000);
        }
    }
}
