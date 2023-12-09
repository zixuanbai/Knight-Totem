using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    protected Animator anim;
    
    public float nomalSpeed;
    public float chaseSpeed;
    public float currentSpeed;
    public Vector3 faceDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = nomalSpeed;
    }
    
    private void Update()
    {
        faceDir = new Vector3(-transform.localScale.x, 0, 0);
    }
    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        rb.velocity = new Vector2(currentSpeed * faceDir.x * Time.deltaTime, rb.velocity.y);
    }
}
