using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Localization.Editor;
using UnityEngine;

public class TextLocalizer : MonoBehaviour
{
    [SerializeField] string key;


    public void Localize()
    {
        GetComponent<TMP_Text>().text = Localization.GetString(key);
    }


    private void Start()
    {
        Localize();
    }
}
