using System.Configuration;

public class ConfigUtil
{
    /// <summary>
    /// 获取Web.Config配置的数据库连接
    /// </summary>
    /// <param name="key">配置的数据库连接名称</param>
    /// <returns></returns>
    public static string GetConnectionString(string key)
    {
        return ConfigurationManager.ConnectionStrings[key].ConnectionString;
    }

    /// <summary>
    /// 获取Web.Config  AppSettings 配置节的信息
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetAppSettings(string key)
    {
        string text = ConfigurationManager.AppSettings[key];
        if (text == null)
        {
            text = string.Empty;
        }
        return text;
    }

    /// <summary>
    /// 获取Web.Config  AppSettings 配置节的信息, 提供默认值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static string GetAppSettings(string key, string defaultValue)
    {
        try
        {
            object text = ConfigurationManager.AppSettings[key];
            return (text == null) ? defaultValue : (string)text;
        }
        catch
        {
            return defaultValue;
        }
    }
}