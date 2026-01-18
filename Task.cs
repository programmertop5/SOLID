using System;

namespace Program.cs;
class AppConfig
{
    private AppConfig() { }


    private static AppConfig _instance;
    private static readonly object _lock = new object();

    private Dictionary<string, string> _settings;

    static AppConfig()
    {
        _instance = new AppConfig();                  
        _instance. _settings = new Dictionary<string, string>();
    }

    public static AppConfig GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AppConfig();
                }
            }
        }
        return _instance;
    }

    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }

    public string GetSetting(string key)
    {
        return _settings[key];
    }
}

class Program
    {
        static void Main(string[] args)
        {
            AppConfig config1 = AppConfig.GetInstance();
            config1.SetSetting("Theme", "Dark");

            AppConfig config2 = AppConfig.GetInstance();
            config2.SetSetting("Language", "English");

            Console.WriteLine(config1.GetSetting("Theme"));     
            Console.WriteLine(config2.GetSetting("Language"));  
        }
    }

