using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Localization : MonoBehaviour
{
    static string filePath;



    [SerializeField] static Dictionary<string, string> stringsCSVEN;
    [SerializeField] static Dictionary<string, string> stringsCSVFR;

    public static bool isInit;


    public static Localization Instance { get; private set; }
    public static string CurrentLanguageCSV { get; internal set; }


    private void Awake()
    {
        Instance = this;      
    }

   public static void Init()
    {
        CSVLoader loader = new CSVLoader();
        loader.LoadCSV();

        stringsCSVEN = loader.GetDictionaryValues("en");
        stringsCSVFR = loader.GetDictionaryValues("fr");
        
        isInit = true;
    }

    public static string GetStringCSV(string stringKey)
    {
        if (!isInit) Init();

        string value = stringKey;

        if (stringsCSVEN.ContainsKey(stringKey)||stringsCSVFR.ContainsKey(stringKey))
        {
            switch (CurrentLanguageCSV)
            {
                case "en":
                    stringsCSVEN.TryGetValue(stringKey, out value);
                    break;
                case "fr":
                    stringsCSVFR.TryGetValue(stringKey, out value);
                    break;
               
                default:
                    stringsCSVEN.TryGetValue(stringKey, out value);
                    break;
            }
            return value;
        }
        else
        {
            Debug.LogWarning("Missing string key: " + stringKey);
            return stringKey;
        }
    }
}
