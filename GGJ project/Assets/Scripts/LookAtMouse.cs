using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shotgunRenderer;
    [SerializeField] private SpriteRenderer grandmaTorsoRenderer;
    [SerializeField] private SpriteRenderer grandmaHeadRenderer;
    [SerializeField] private SpriteRenderer grandmaGatorRenderer;
    [SerializeField] private SpriteRenderer grandmaLeg1Renderer;
    [SerializeField] private SpriteRenderer grandmaLeg2Renderer;
    private bool activationState = true;

    private void Update()
    {
        if(activationState)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            if(direction.x >= 0  && shotgunRenderer.flipX == true)
            {
                shotgunRenderer.flipX = false;
                grandmaTorsoRenderer.flipX = false;
                grandmaHeadRenderer.flipX = false;
                grandmaGatorRenderer.flipX = false;
                grandmaLeg1Renderer.flipX = false;
                grandmaLeg2Renderer.flipX = false;
            }
            if(direction.x <= 0 && shotgunRenderer.flipX == false)
            {
                shotgunRenderer.flipX = true;
                grandmaTorsoRenderer.flipX = true;
                grandmaHeadRenderer.flipX = true;
                grandmaGatorRenderer.flipX = true;
                grandmaLeg1Renderer.flipX = true;
                grandmaLeg2Renderer.flipX = true;
            }

            if(Mathf.Abs(direction.x) > 0.1f && Mathf.Abs(direction.y) > 0.1f)
            {
                transform.up = direction;
            }
        }
    }

    public void PublicActivate()
    {
        activationState = true;
    }

    public void PublicDeactivate()
    {
        activationState = false;
    }
}
