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
    [SerializeField] GameObject Player;
    [SerializeField] GameObject DeathPanel;
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
    public void Revive()
    {
        Player.transform.position = new Vector3(0, 0, -1);
        player.PlayerHealth = player.MaxPlayerHealth;
        player.PlayerOxygen = player.MaxPlayerOxygen;
        DeathPanel.SetActive(false);
        Player.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        Player.GetComponent<Rigidbody2D>().constraints = 0;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
   
    private void Update()
    {
        if (player.PlayerHealth <= 0)
        {
            DeathPanel.SetActive(true);
        }
    }
}
