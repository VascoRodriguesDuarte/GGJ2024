using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Shoot shoot;
    [SerializeField] private LookAtMouse lookAtMouse;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private SpriteRenderer defaultSprite;
    [SerializeField] private SpriteRenderer shotgunSprite;
    // [SerializeField] private SpriteRenderer ragdollSprite;

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
}
