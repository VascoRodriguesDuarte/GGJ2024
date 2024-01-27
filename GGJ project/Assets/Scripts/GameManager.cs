using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager GMInstance;
    public int deathCount = 0;
    public TextMeshProUGUI deathCountTxt;
    public int checkPoint = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (GMInstance == null)
        {
            GMInstance = this;
            deathCount = 0;
            
        }
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if(deathCountTxt != null)
            deathCountTxt.text = "Deaths: " + deathCount.ToString();
    }
    public void AddDeath()
    {
        deathCount++;
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(GMInstance);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        deathCount = data.deaths;
        checkPoint = data.lastCheckPoint;
    }
}
