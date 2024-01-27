using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    private bool activationState = true;

    private void Update()
    {
        if(activationState)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            transform.up = direction;
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
