using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private InputAction movement;
    private PlayerInputs playerInputs;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputs= new PlayerInputs();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        movement = playerInputs.Player.Move;
        movement.Enable();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    private void FixedUpdate()
    {
        //Debug.Log(rb.velocity.x);

        if(IsGrounded())
        {
            // rb.velocity = new Vector2(movement.ReadValue<float>() * speed, rb.velocity.y);
            float input = movement.ReadValue<float>();
            Vector2 vel = rb.velocity;

            if (input > 0.01 && vel.x < speed && Mathf.Sign(vel.x) == 1)
            {
                vel.x = speed;
            } 
            else if(input < -0.01 && Mathf.Abs(vel.x) < speed && (Mathf.Sign(vel.x) == -1 || vel.x == 0))
            {
                vel.x = -speed;
            }

            rb.velocity = vel;
        }
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
