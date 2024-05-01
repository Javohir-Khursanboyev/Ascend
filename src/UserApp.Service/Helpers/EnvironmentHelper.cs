namespace UserApp.Service.Helpers;

public static class EnvironmentHelper 
{
    public static string WebRootPath { get; set; }
    public static int DefaultPageIndex { get; set; }
    public static int DefaultPageSize { get; set; }
    public static string JWTKey { get; set; }
    public static string TokenLifeTimeInHours { get; set; }
}