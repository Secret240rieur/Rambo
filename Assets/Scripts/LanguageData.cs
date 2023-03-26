using System;

[Serializable]
public class LanguageData
{
    public string key;
    public string en;
    public string fr;
}

[Serializable]
public class StringsData
{
    public LanguageData[] strings;

}

