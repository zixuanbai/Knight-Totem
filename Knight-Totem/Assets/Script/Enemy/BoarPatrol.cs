using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarPatrol : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.nomalSpeed;
    }

    public override void LogicUpdate()
    {
        if (currentEnemy.FoundPlayer())
        {
            currentEnemy.SwitchState(NPCState.Chase);
        }
        if (!currentEnemy.physicsCheck.isGround || (currentEnemy.physicsCheck.touchLeftWall && currentEnemy.faceDir.x < 0) || (currentEnemy.physicsCheck.touchRightWall && currentEnemy.faceDir.x > 0))
        {
            currentEnemy.wait = true;
            currentEnemy.anim.SetBool("Walk", false);
        }
        else
        {
            
            currentEnemy.anim.SetBool("Walk", true);
            
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
    
    public override void OnExit()
    {
        
    }
}
