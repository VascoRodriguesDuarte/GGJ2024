using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlayerEnter; // UnityEvent to invoke when the player enters the trigger zone
    [SerializeField] private string playerTag; // The layer(s) that represent the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onPlayerEnter.Invoke(); // Invoke the UnityEvent when the player enters the trigger zone
        }
    }
}
