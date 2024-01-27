using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int deaths;
    public int lastCheckPoint;


    public PlayerData (GameManager gameManager)
    {
        deaths = gameManager.deathCount;
        lastCheckPoint = gameManager.checkPoint;
    }
}
