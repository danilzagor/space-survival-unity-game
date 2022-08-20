using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGame : MonoBehaviour
{
    [SerializeField] GameObject[] Bars;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject InteractiveCollider;
    [SerializeField] Text NumberOfAttemptsText;
    [SerializeField] GameObject[] EnemiesPrefabs;
    [SerializeField] GameObject[] EnemiesSpawnPoints;
    int i = 0;
    bool changinColor;
    int score;
    int attepmts;
    Color color;
    private void Start()
    {
        i = 0;
        score = 0;
        attepmts = 3;
    }
    private void FixedUpdate()
    {
        NumberOfAttemptsText.text = "You have " + attepmts + " attempts.";
        if (changinColor == false && i<3 && attepmts>=0)
        {
            StartCoroutine(ChangingColors(0.45f));
        }
        if (score == 3)
        {
            Panel.SetActive(false);
            Destroy(InteractiveCollider);

        }
    }
    public void PressButtonMiniGame()
    {

        if (color == new Color32(8, 132, 34, 255))
        {
            score++;
            i++;
        }
        else
        {
            attepmts--;
            if (attepmts <= 0)
            {
                Panel.SetActive(false);
                Invoke("SpawnEnemies",1f);
                
            }
        }
    }
    IEnumerator ChangingColors(float time)
    {
        changinColor = true;   
        yield return new WaitForSeconds(time);
        color = RandomColor();
        Bars[i].GetComponent<Image>().color = color;
        
        changinColor = false;
    }
    
    private Color RandomColor()
    {
        int randomNumber = Random.Range(0,7);
        switch(randomNumber) 
        {
            case 0: return Color.black; 
            case 1: return Color.blue; 
            case 2: return Color.cyan;
            case 3: return new Color32(8,132,34,255);
            case 4: return Color.grey;
            case 5: return Color.red;
            case 6: return Color.yellow;
        }
        return Color.black;        
    }
    private void SpawnEnemies()
    {
        for(int j = 0; j <= EnemiesPrefabs.Length - 1; j++)
        {
            Instantiate(EnemiesPrefabs[Random.Range(0, EnemiesPrefabs.Length + 1)], EnemiesSpawnPoints[j].transform);
            Debug.Log(j);
        }
        
    }
}
