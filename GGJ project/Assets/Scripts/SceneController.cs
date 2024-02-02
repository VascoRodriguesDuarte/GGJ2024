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
    [SerializeField] private bool ispaused = false;
    [SerializeField] private bool isMainMenu = false;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        pause = playerInputs.Player.Pause;
        pause.Enable();
    }
    private void Start()
    {
        playerInputs = new PlayerInputs();
        gm = Object.FindObjectOfType<GameManager>();
        gm.deathCountTxt = deathCountTxt;
        ispaused = false;
    }

    private void Update()
    {
        if(isMainMenu)
            return;

        if (pause.WasPerformedThisFrame())
            PauseGame();
    }

    public void GoToScene(int sceneID)
    {
        if(sceneID == 0)
        {
            isMainMenu = true;
            if(gm != null)
                gm.SaveGame();
        }
        else
        {
            isMainMenu = false;

        }
        SceneManager.LoadScene(sceneID);

    }


    public void LoadGame(int sceneID)
    {
        if(gm != null)
            gm.LoadGame();
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void RestartScene()
    {
        gm.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void ResetStats()
    {
        if (gm == null)
            return;

        gm.deathCount = 0;
        gm.SaveGame();
    }

    public void DeathMenu()
    {
        gm.AddDeath();
        deathEvents.Invoke();
    }

    public void PauseGame()
    {
        if (!ispaused)
        {
            player.PausePlayer();
            pauseEvent.Invoke();
            ispaused = true;
            Time.timeScale = 0;
        }
        else
        {
            player.UnpausePlayer();
            unpauseEvent.Invoke();
            ispaused = false;
            Time.timeScale = 1;
        }
    }

    private void OnDisable()
    {
        pause.Disable();
    }
}
