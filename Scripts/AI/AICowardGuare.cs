using UnityEngine;

public class AICowardGuare : AIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        ChangeState(AIState.choose);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void MakeDecisions()
    {
        base.MakeDecisions();
        switch (currentState)
        {
            case AIState.choose:
            TargetPlayerOne();
            ChangeState(AIState.Seek);
            break;
            
            case AIState.patrol:
            patrol();
            if(IsDisntanceLessThan(target, 4))
            {
                ChangeState(AIState.flee);
            }
            break;

            case AIState.flee:
            Flee2();
            if(IsDisntanceLessThan(target,3))
            {
                ChangeState(AIState.Attack);
            }
           break;

            case AIState.Attack:
            DoAttackState();
            //if were too close to teh player go idle
            if (!IsDisntanceLessThan(target,5))
            {
                ChangeState(AIState.Seek);
            }
            break;

            case AIState.Seek:
            DoSeekState();
            if(IsDisntanceLessThan(target, 10))
            {
                ChangeState(AIState.flee);
            }
            break;
        }
    }
}
