using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneController : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI deathCountTxt;

    private void Start()
    {
        gm = Object.FindObjectOfType<GameManager>();
        gm.deathCountTxt = deathCountTxt;
    }
    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void RestartScene()
    {
        gm.AddDeath();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
