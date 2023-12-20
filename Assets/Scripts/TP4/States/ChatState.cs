using UnityEngine;

public class ChatState : BaseState {
    float chatTime = 5f;
    public override void OnEnterState(EnemyStateMachine stateMachine) {
        chatTime = 5f;
    }

    public override void OnExitState(EnemyStateMachine stateMachine) {
        
    }

    public override void UpdateState(EnemyStateMachine stateMachine) {
        float distance = MathHelper.VectorDistance(stateMachine.chatGuard.transform.position, stateMachine.transform.position);
        if(distance <= 6f) {
            if(chatTime > 0) {
                chatTime -= Time.deltaTime;
            } else {
                stateMachine.SwitchState(stateMachine.patrolState);
            }
        } else {
            stateMachine.SwitchState(stateMachine.patrolState);
        }
    }
}
