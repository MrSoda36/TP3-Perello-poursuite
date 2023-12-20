using UnityEngine;

public abstract class BaseState
{
    public abstract void OnEnterState(EnemyStateMachine stateMachine);
    public abstract void OnExitState(EnemyStateMachine stateMachine);
    public abstract void UpdateState(EnemyStateMachine stateMachine);
}
