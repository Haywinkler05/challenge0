using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int wayPointIndex;
    public float waitTimer;
    // Start is called before the first frame update
    public override void Enter()
    {
        
    }
    public override void Preform()
    {
        patrolCycle();
        if (enemy.canSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {

    }

    public void patrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 3)
            {

                if (wayPointIndex < enemy.path.waypoints.Count - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[wayPointIndex].position);
                waitTimer = 0;
            }
        }
    }

}
