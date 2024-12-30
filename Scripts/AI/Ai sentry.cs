using UnityEngine;

public class Aisentry : AIController
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
        switch(currentState)
        {
            case AIState.choose:
            TargetPlayerOne();
            ChangeState(AIState.patrol);
            break;

            case AIState.patrol:
            patrol();
            if(IsDisntanceLessThan(target, 5))
            {
                ChangeState(AIState.Attack);
            }
            break;

            case AIState.Attack:
            DoAttackState();
            break;
        }
    }
}
