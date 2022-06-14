using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject SettingsPanel;
    bool PanelIsOpen = false;
    [SerializeField] AudioSource[] audioSources;
    public void OpenCloseMenuPanel()
    {
        PanelIsOpen = !PanelIsOpen;
        Panel.SetActive(PanelIsOpen);
    }
    public void SettingsMenu()
    {
        PanelIsOpen = !PanelIsOpen;
        Panel.SetActive(PanelIsOpen);
        SettingsPanel.SetActive(true);
    }
    public void Back()
    {
        PanelIsOpen = !PanelIsOpen;
        Panel.SetActive(PanelIsOpen);
        SettingsPanel.SetActive(false);
    }
    public void Continue()
    {
        PanelIsOpen = !PanelIsOpen;
        Panel.SetActive(PanelIsOpen);
    }
    public void BackInMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Mute()
    {
        int isMute = PlayerPrefs.GetInt("IsMute");

        foreach (AudioSource audio in audioSources)
        {
            if (isMute == 0)
            {
                audio.volume = 0;
                
            }
            if (isMute == 1)
            {
                audio.volume = 0.3f;
            }
        }
        if (isMute == 0)
        {
            isMute = 1;

        }else
        if (isMute == 1)
        {
            isMute = 0;
        }

        PlayerPrefs.SetInt("IsMute",isMute);
    }
}
