using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] GameObject MinigamePanel;
    [SerializeField] GameObject OpenMinigameButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            OpenMinigameButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            OpenMinigameButton.SetActive(false);
        }
    }
    public void OpenMiniGame()
    {
        MinigamePanel.SetActive(true);
        OpenMinigameButton.SetActive(false);
    }
}
