namespace Ficbook.Services;

public static class PathDb
{
    public static string GetPath(string nameDb)
    {
        string pathDbSqlite = string.Empty;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
        }

        return pathDbSqlite;
    }
}