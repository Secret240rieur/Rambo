using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings.Switch;

public class UIController : MonoBehaviour
{

    string language = "en";

    public void SetLanguage(int val)
    {
        if(val==0) language = "en";
        if(val==1) language = "fr";
        if(val==2) language = "de";
        if(val==3) language = "ru";
        if(val==4) language = "es";
        Debug.Log(language);
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrWhiteSpace(language))
        {
            Localization.CurrentLanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.Localize());
        }
    }
}
