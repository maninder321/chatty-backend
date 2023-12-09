namespace Chatty.ApplicationCore.Utilities;

public class CommonUtilityFunctions
{

    public static DateTime GetCurrentInGivenTimeZone(String timeZoneString)
    {
        TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneString);
        DateTime dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timezone);
        return dateTime;
    }

}