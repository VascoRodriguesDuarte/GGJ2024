using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("enter");

        if(collision.CompareTag("Player"))
              rig.bodyType = RigidbodyType2D.Dynamic;
    }
}
