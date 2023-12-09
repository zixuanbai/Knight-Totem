using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public PhysicsMaterial2D Normal;
    public PhysicsMaterial2D wall;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private PlayerAnimation playerAnimation;
    private bool canDoubleJump;
    private Collider2D coll;
    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;
    public float damageForce;
    public bool isDamaged;
    public bool isDied;
    public bool isAttack;
    
    

   private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb=GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        physicsCheck = GetComponent<PhysicsCheck>();
        inputControl.Gameplay.Jump.started += Jump;
        inputControl.Gameplay.Attack.started += PlayerAttack;
        coll = GetComponent<Collider2D>();

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
        
        if (physicsCheck.isGround)
        {
            canDoubleJump = true;
        }
        CheckState();
    }
    private void FixedUpdate()
    {
        if(!isDamaged &&!isAttack)
        Move();
    }

    public void Move()
    {
        if (!isAttack)
        {
            rb.velocity = new Vector2(inputDirection.x * speed, rb.velocity.y);
            if (inputDirection.x > 0 && transform.localScale.x < 0 ||
                inputDirection.x < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
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

    private void PlayerAttack(InputAction.CallbackContext obj)
    {
        playerAnimation.PlayAttack();
        isAttack = true;
        
    }
    public void GetDamaged(Transform attacker)
    {
        isDamaged = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;
        rb.AddForce(dir * damageForce, ForceMode2D.Impulse);
    }
    public void PlayerDied()
    {
        isDied = true;
        inputControl.Gameplay.Disable();

    }

    private void CheckState()
    {
        coll.sharedMaterial= physicsCheck.isGround?Normal: wall;
    }
}

