using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{

    public bool horizontal;
    private Rigidbody2D rig;
    private ConstantForce2D constF;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        constF = GetComponent<ConstantForce2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!horizontal)
            {
                rig.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                constF.enabled = true;
            }
        }
            

    }
}
