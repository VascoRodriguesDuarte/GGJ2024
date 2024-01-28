using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shotgunRenderer;
    [SerializeField] private SpriteRenderer grandmaRenderer;
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
                grandmaRenderer.flipX = false;
            }
            if(direction.x <= 0 && shotgunRenderer.flipX == false)
            {
                shotgunRenderer.flipX = true;
                grandmaRenderer.flipX = true;
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
