using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager GMInstance;
    public int deathCount = 0;
    public TextMeshProUGUI deathCountTxt;
    public int checkPoint = 0;

    public List<PlayersScore> playersScores = new List<PlayersScore>();
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI firstScoreTxt;
    public TextMeshProUGUI firstNameTxt;
    public TextMeshProUGUI secondScoreTxt;
    public TextMeshProUGUI secondNameTxt;
    public TextMeshProUGUI thirdScoreTxt;
    public TextMeshProUGUI thirdNameTxt;
    public TextMeshProUGUI forthScoreTxt;
    public TextMeshProUGUI forthNameTxt;
    public TextMeshProUGUI fifthScoreTxt;
    public TextMeshProUGUI fifthNameTxt;
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

    public void LoadScoreboard()
    {
        LeaderBoardData data = SaveSystem.LoadScoreboard();
        playersScores.Clear();
        for(int x = 0; x < 5; x++)
        {
            PlayersScore tmp = new PlayersScore(data.names[x], data.scores[x]);
            playersScores.Add(tmp);
        }
        SortList();
    }


    public void SaveScoreboard()
    {
        SaveSystem.SaveScoreboard(GMInstance);
    }

    public void AddPlayer()
    {
        playersScores.Add(new PlayersScore(nameText.text, deathCount));
        playersScores = playersScores.OrderByDescending(x => x.score).ToList();
        SortList();
        if (playersScores.Count > 5)
            playersScores.RemoveAt(5);
    }

    public void SortList()
    {
        playersScores = playersScores.OrderBy(x => x.score).ToList();
        firstNameTxt.text = playersScores[0].playerName;
        firstScoreTxt.text = playersScores[0].score.ToString();
        secondNameTxt.text = playersScores[1].playerName;
        secondScoreTxt.text = playersScores[1].score.ToString();
        thirdNameTxt.text = playersScores[2].playerName;
        thirdScoreTxt.text = playersScores[2].score.ToString();
        forthNameTxt.text = playersScores[3].playerName;
        forthScoreTxt.text = playersScores[3].score.ToString();
        fifthNameTxt.text = playersScores[4].playerName;
        fifthScoreTxt.text = playersScores[4].score.ToString();
    }
}
