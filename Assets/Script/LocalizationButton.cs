using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;


public class LocalizationButton : MonoBehaviour
{
    int i = 0;
    public void Setlanguage()
    {
        StartCoroutine("setLanguage");
    }
    public IEnumerator setLanguage()
    {
        // Wait for the localization system to initialize, loading Locales, preloading, etc.
        yield return LocalizationSettings.InitializationOperation;

        // This variable selects the language. For example, if in the table your first language is English then 0 = English. If the second language in the table is Russian then 1 = Russian etc.
        if (i+1 == LocalizationSettings.AvailableLocales.Locales.Count)
        {
            i = 0;
        }else
        i++;

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }

}
