using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] public Shoot shoot;
    [SerializeField] private LookAtMouse lookAtMouse;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private SpriteRenderer defaultTorsoSprite;
    [SerializeField] private SpriteRenderer defaultHeadSprite;
    [SerializeField] private SpriteRenderer defaultLeg1Sprite;
    [SerializeField] private SpriteRenderer defaultLeg2Sprite;
    [SerializeField] private SpriteRenderer defaultGatorSprite;
    [SerializeField] private SpriteRenderer shotgunSprite;
    private SceneController sceneCont;
    [SerializeField] private GameObject gator;
    [SerializeField] private GameObject ragdoll;
    // [SerializeField] private SpriteRenderer ragdollSprite;

    private void Start()
    {
        gator.SetActive(false);
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
        defaultTorsoSprite.enabled = false;
        defaultHeadSprite.enabled = false;
        defaultLeg1Sprite.enabled = false;
        defaultLeg2Sprite.enabled = false;
        defaultGatorSprite.enabled = false;
        shotgunSprite.enabled = false;
        ragdoll.SetActive(true);
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
        defaultTorsoSprite.enabled = true;
        shotgunSprite.enabled = true;
        ragdoll.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hurt"))
        {
            sceneCont.DeathMenu();
            DeactivatePlayer();

        }

        if (collision.CompareTag("Gator"))
        {
            gator.SetActive(true);
        }
    }
}
