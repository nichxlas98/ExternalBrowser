using System;
using System.IO;
using System.Text.Json;

public class HotkeyConfig
{
    public int Hotkey { get; set; }

    // Default constructor
    public HotkeyConfig()
    {
        Hotkey = 0xA5; // RIGHT_ALT
    }

    // Constructor with hotkey value
    public HotkeyConfig(int hotkey)
    {
        Hotkey = hotkey;
    }

    // Save the hotkey to a JSON file named "hotkey.json" in the program's directory
    public void SaveToJson()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotkey.json");

        try
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving hotkey to JSON: {ex.Message}");
        }
    }

    // Get the hotkey from a JSON file named "hotkey.json" in the program's directory
    public static HotkeyConfig LoadFromJson()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotkey.json");

        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<HotkeyConfig>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading hotkey from JSON: {ex.Message}");
        }

        // If file doesn't exist or there's an error, return a default instance
        return new HotkeyConfig();
    }
}
