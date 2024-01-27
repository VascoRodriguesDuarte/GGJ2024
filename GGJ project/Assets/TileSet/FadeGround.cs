using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGround : MonoBehaviour
{
    Animator anim;
    public bool playerIn;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("playerIn", playerIn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerIn = false;
    }

}
