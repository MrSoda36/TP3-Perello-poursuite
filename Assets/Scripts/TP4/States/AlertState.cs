using UnityEngine;

public class AlertState : BaseState {
    float timePassed = 0f;
    Vector3 lastTarget;

    public override void OnEnterState(EnemyStateMachine stateMachine) {
        timePassed = 0f;
        lastTarget = stateMachine.player.transform.position;
    }

    public override void OnExitState(EnemyStateMachine stateMachine) {
        
    }

    public override void UpdateState(EnemyStateMachine stateMachine) {
        float distance = MathHelper.VectorDistance(lastTarget, stateMachine.transform.position);
        if(distance <= 7f) {
            stateMachine.agent.SetDestination(lastTarget);
            if(MathHelper.VectorDistance(lastTarget, stateMachine.transform.position) <= 0.3f) {
                stateMachine.SwitchState(stateMachine.patrolState);
                return;
            }

            if(MathHelper.VectorDistance(stateMachine.player.transform.position, stateMachine.transform.position) <= 5f) {
                stateMachine.SwitchState(stateMachine.pursuitState);
                return;
            }
        } else {
            if(timePassed > 5f) {
                stateMachine.SwitchState(stateMachine.patrolState);
            } else {
                timePassed += Time.deltaTime;
            }
        }

    }
}
