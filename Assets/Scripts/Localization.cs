using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Localization : MonoBehaviour
{
    static string filePath;



    [SerializeField] static Dictionary<string, string> stringsCSVEN;
    [SerializeField] static Dictionary<string, string> stringsCSVFR;
    [SerializeField] static Dictionary<string, string> stringsCSVDE;
    [SerializeField] static Dictionary<string, string> stringsCSVRU;
    [SerializeField] static Dictionary<string, string> stringsCSVCH;
    [SerializeField] static Dictionary<string, string> stringsCSVe;

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
        stringsCSVDE = loader.GetDictionaryValues("de");
        stringsCSVRU = loader.GetDictionaryValues("ru");
        stringsCSVCH = loader.GetDictionaryValues("es");
        stringsCSVe = loader.GetDictionaryValues("E");
        
        isInit = true;
    }

    public static string GetStringCSV(string stringKey)
    {
        if (!isInit) Init();

        string value = stringKey;

        if (stringsCSVEN.ContainsKey(stringKey)||stringsCSVFR.ContainsKey(stringKey)||
            stringsCSVDE.ContainsKey(stringKey)|| stringsCSVRU.ContainsKey(stringKey)|| stringsCSVCH.ContainsKey(stringKey))
        {
            switch (CurrentLanguageCSV)
            {
                case "en":
                    stringsCSVEN.TryGetValue(stringKey, out value);
                    break;
                case "fr":
                    stringsCSVFR.TryGetValue(stringKey, out value);
                    break;
                case "de":
                    stringsCSVDE.TryGetValue(stringKey, out value);
                    break;
                case "ru":
                    stringsCSVRU.TryGetValue(stringKey, out value);
                    break;
                case "es":
                    stringsCSVCH.TryGetValue(stringKey, out value);
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
