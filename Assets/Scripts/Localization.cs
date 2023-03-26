using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Localization : MonoBehaviour
{
    static string filePath;



    static Dictionary<string, LanguageData> strings = new();

    public static Localization Instance { get; private set; }
    public static string CurrentLanguage { get; internal set; }

    private void Awake()
    {
        Instance = this;
        filePath = Path.Combine(Application.streamingAssetsPath, "Strings.json");
        string json = File.ReadAllText(filePath);

        var data = JsonUtility.FromJson<StringsData>(json);


        foreach (LanguageData languageData in data.strings)
        {
            strings.Add(languageData.key, languageData);
        }

    }

   

    public static string GetString(string stringKey)
    {

        if (strings.ContainsKey(stringKey))
        {
            switch (CurrentLanguage)
            {
                case "en":
                    return strings[stringKey].en;

                case "fr":
                    return strings[stringKey].fr;
                default:
                    return strings[stringKey].en;
            };
        }
        else
        {
            Debug.LogWarning("Missing string key: " + stringKey);
            return stringKey;
        }
    }
}
