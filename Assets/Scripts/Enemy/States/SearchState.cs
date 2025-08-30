using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{

    private float searchTimer;
    private float moveTimer;
    public override void Enter()
    {
        Debug.Log("Entered Search state");
       enemy.Agent.SetDestination(enemy.LastKnownPos);
    }

    public override void Exit()
    {
       
    }

    public override void Preform()
    {
        Debug.Log("Entering preform function");
        if (enemy.canSeePlayer())

        {
            stateMachine.ChangeState(new AttackState());
        }
        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance) 
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if(searchTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
        }
    }
}
