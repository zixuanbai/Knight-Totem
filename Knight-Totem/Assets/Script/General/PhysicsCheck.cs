using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool isGround;
    public float checkRaduis;
    public Vector2 bottomOffset;


    private void Update()
    {
        Check();
    }

   public void Check()
    {
      isGround= Physics2D.OverlapCircle((Vector2)transform.position, checkRaduis, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
}
