using UnityEngine;

public class PursuitState : BaseState {
    public Transform player;
    public bool isPlayerTouched = false;

    public override void OnEnterState(EnemyStateMachine stateMachine) {
            
    }

    public override void OnExitState(EnemyStateMachine stateMachine) {
        
    }

    public override void UpdateState(EnemyStateMachine stateMachine) {
        float distance = MathHelper.VectorDistance(stateMachine.player.transform.position, stateMachine.transform.position);
        if(distance <= 4f) {
            if(!isPlayerTouched) {
                stateMachine.agent.SetDestination(stateMachine.player.transform.position);

                if(MathHelper.VectorDistance(stateMachine.player.transform.position, stateMachine.transform.position) <= 0.3f) {
                    isPlayerTouched = true;
                    stateMachine.SwitchState(stateMachine.patrolState);
                    return;
                } 

            }
            
        }else {
            stateMachine.SwitchState(stateMachine.patrolState);
        }
    }
}
