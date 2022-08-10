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
    [SerializeField] GameObject NewGamePanel;
    [SerializeField] GameObject ContinueButton;
    int FirstTimeLaunch;
    public static int IsMute;
    private void Awake()
    {
        IsMute = PlayerPrefs.GetInt("IsMute");
        FirstTimeLaunch = PlayerPrefs.GetInt("FirstTimeLaunch");

        if (IsMute == 0)
        {
            MenuMusic.volume = 1f;
        }else
        if (IsMute == 1)
        {
            MenuMusic.volume = 0;
        }
        NewGamePanel.SetActive(false);
        if (FirstTimeLaunch == 0)
        {
            ContinueButton.SetActive(false);
            FirstTimeLaunch = 1;
            PlayerPrefs.SetInt("FirstTimeLaunch", FirstTimeLaunch);

        }
    }
    public void Continue()
    {

        SceneManager.LoadScene("Game", LoadSceneMode.Single);

        IsNewGame = 0;
    }
    public void NewGame()
    {
        NewGamePanel.SetActive(true);
    }
    public void NewGameNo()
    {
        NewGamePanel.SetActive(false);
    }
    public void NewGameYes()
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
