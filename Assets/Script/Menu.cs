using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static int IsNewGame;//1-new game, 0-continued game
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject SettingsCanvas;
    [SerializeField] GameObject AuthorsCanvas;
    [SerializeField] AudioSource MenuMusic;
    public static int IsMute;
    private void Awake()
    {
        IsMute = PlayerPrefs.GetInt("IsMute");

        if (IsMute == 0)
        {
            MenuMusic.volume = 0.3f;
        }else
        if (IsMute == 1)
        {
            MenuMusic.volume = 0;
        }
    }
    public void Continue()
    {

        SceneManager.LoadScene("Game", LoadSceneMode.Single);

        IsNewGame = 0;
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);

        IsNewGame = 1;
    }
    public void Settings()
    {
        SettingsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
    public void Authors()
    {
        AuthorsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SettingsCanvas.SetActive(false);
        AuthorsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }
    public void Mute()
    {

        if (IsMute == 0)
        {
            MenuMusic.volume = 0;
            IsMute = 1;
        }
        else
        if (IsMute == 1)
        {
            MenuMusic.volume = 0.3f;           
            IsMute = 0;
        }
            
        PlayerPrefs.SetInt("IsMute", IsMute);
    }
}
