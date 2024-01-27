using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] public Shoot shoot;
    [SerializeField] private LookAtMouse lookAtMouse;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private SpriteRenderer defaultSprite;
    [SerializeField] private SpriteRenderer shotgunSprite;
    private SceneController sceneCont;
    // [SerializeField] private SpriteRenderer ragdollSprite;

    private void Start()
    {
        sceneCont = Object.FindObjectOfType<SceneController>();
    }

    public void PublicDeathPing()
    {
        DeactivatePlayer();
    }

    public void PublicAlivePing()
    {
        ActivatePlayer();
    }

    private void DeactivatePlayer()
    {
        playerMovement.PublicDeactivate();
        shoot.PublicDeactivate();
        lookAtMouse.PublicDeactivate();
        defaultSprite.enabled = false;
        shotgunSprite.enabled = false;
        //ragdollSprite.enabled = true;
    }


    public void PausePlayer()
    {
        playerMovement.PublicDeactivate();
        shoot.PublicDeactivate();
        lookAtMouse.PublicDeactivate();
    }

    public void UnpausePlayer()
    {
        playerMovement.PublicActivate();
        shoot.PublicActivate();
        lookAtMouse.PublicActivate();
    }

    private void ActivatePlayer()
    {
        this.transform.position = spawnPoint.position;
        playerMovement.PublicActivate();
        shoot.PublicActivate();
        lookAtMouse.PublicActivate();
        defaultSprite.enabled = true;
        shotgunSprite.enabled = true;
        //ragdollSprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hurt"))
        {
            sceneCont.DeathMenu();
            DeactivatePlayer();

        }
    }
}
