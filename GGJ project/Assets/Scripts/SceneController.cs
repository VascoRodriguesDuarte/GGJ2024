using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SceneController : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI deathCountTxt;
    [SerializeField] private UnityEvent deathEvents;
    public PlayerManager player;
    private InputAction pause;
    [SerializeField] private PlayerInputs playerInputs;
    [SerializeField] private UnityEvent pauseEvent;
    [SerializeField] private UnityEvent unpauseEvent;
    private bool ispaused = false;

    private void OnEnable()
    {
        pause = player.shoot.playerInputs.Player.Pause;
        pause.Enable();
    }
    private void Start()
    {
        playerInputs = new PlayerInputs();
        gm = Object.FindObjectOfType<GameManager>();
        gm.deathCountTxt = deathCountTxt;
        ispaused = true;
    }

    private void Update()
    {
        if (pause.WasPerformedThisFrame())
        {

            PauseGame();
        }

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

    public void DeathMenu()
    {
        deathEvents.Invoke();
    }

    public void PauseGame()
    {
        if (!ispaused)
        {
            player.PausePlayer();
            pauseEvent.Invoke();
            ispaused = true;
        }
        else
        {
            player.UnpausePlayer();
            unpauseEvent.Invoke();
            ispaused = false;
        }
    }
}
