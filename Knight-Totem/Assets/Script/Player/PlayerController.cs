using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private bool canDoubleJump;
    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;



   private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb=GetComponent<Rigidbody2D>();

        physicsCheck = GetComponent<PhysicsCheck>();
        inputControl.Gameplay.Jump.started += Jump;

    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        transform.Translate(inputDirection * speed * Time.deltaTime);
        if (physicsCheck.isGround)
        {
            canDoubleJump = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed , rb.velocity.y);
        if (inputDirection.x > 0 && transform.localScale.x < 0 ||
            inputDirection.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        if (physicsCheck.isGround || canDoubleJump)
        {
            
            if (!physicsCheck.isGround)
            {
                canDoubleJump = false; 
            }

            
            rb.velocity = new Vector2(rb.velocity.x, 0); 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}

