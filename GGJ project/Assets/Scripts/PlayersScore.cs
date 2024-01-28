using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayersScore 
{
    public string playerName;
    public int score;

    public PlayersScore(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}


[System.Serializable]
public class LeaderBoardData
{
    public string[] names;
    public int[] scores;

    public LeaderBoardData(GameManager gm)
    {
        if (gm.playersScores.Count < 5)
        {
            var tmp = gm.playersScores.Count;
            for (int i = tmp; i < 5; i++)
                gm.playersScores.Add(new PlayersScore("AAA", 9999));
        }


        names = new string[5];
        scores = new int[5];
        names[0] = gm.playersScores[0].playerName;
        names[1] = gm.playersScores[1].playerName;
        names[2] = gm.playersScores[2].playerName;
        names[3] = gm.playersScores[3].playerName;
        names[4] = gm.playersScores[4].playerName;
    
        scores[0] = gm.playersScores[0].score;
        scores[1] = gm.playersScores[1].score;
        scores[2] = gm.playersScores[2].score;
        scores[3] = gm.playersScores[3].score;
        scores[4] = gm.playersScores[4].score;

    }
}
