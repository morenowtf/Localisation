using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LocalisationSystem : MonoBehaviour 
{
    public enum Language
    {
        English,
        Russian
    }

    public static Language language = Language.English;


    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedRU;

    public static bool isNit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedRU = csvLoader.GetDictionaryValues("ru");

        isNit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isNit) {  Init(); }

        string value = key;

        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Russian:
                localisedRU.TryGetValue(key, out value);
                break;
        }

        return value;
    }

    
    public void SetEnglish()
    {

        language = Language.English;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetRussian()
    {
        language = Language.Russian;
        SceneManager.LoadScene("MainMenu");

    }
}
