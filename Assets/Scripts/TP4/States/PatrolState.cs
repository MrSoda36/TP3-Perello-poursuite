using System;
using UnityEngine;

public class PatrolState : BaseState {
    public Waypoint currentWaypoint;
    public int currentWaypointIndex = 0;
    public float speed = 5f;
    public bool isWaypointTouched = false;
    public Transform player;

    public override void OnEnterState(EnemyStateMachine stateMachine) {
        currentWaypoint = stateMachine.waypoints[currentWaypointIndex];
        stateMachine.doneWaypoints[currentWaypointIndex] = stateMachine.waypoints[currentWaypointIndex];
        stateMachine.doneWaypoints = new Waypoint[stateMachine.waypoints.Length];

    }

    public override void OnExitState(EnemyStateMachine stateMachine) {
        
    }

    public override void UpdateState(EnemyStateMachine stateMachine) {
        if (!isWaypointTouched) {
            stateMachine.agent.SetDestination(currentWaypoint.transform.position);

            if (MathHelper.VectorDistance(currentWaypoint.transform.position, stateMachine.transform.position) <= 0.3f) {
                isWaypointTouched = true;
                return;
            }

            if(MathHelper.VectorDistance(stateMachine.player.transform.position, stateMachine.transform.position) <= 5f) {
                stateMachine.SwitchState(stateMachine.pursuitState);
                return;
            }

            if(MathHelper.VectorDistance(stateMachine.chatGuard.transform.position, stateMachine.transform.position) <= 6f) {
                stateMachine.SwitchState(stateMachine.chatState);
                return;
            }

        }
        else {
            if(currentWaypointIndex == stateMachine.waypoints.Length - 1 ) {
                currentWaypointIndex = 0;
                Array.Clear(stateMachine.doneWaypoints, 0, stateMachine.waypoints.Length);
                currentWaypoint = stateMachine.waypoints[currentWaypointIndex];
            } else {
                stateMachine.doneWaypoints[currentWaypointIndex] = currentWaypoint;
                currentWaypointIndex++;
                currentWaypoint = stateMachine.waypoints[currentWaypointIndex];
            }
            isWaypointTouched = false;
        }
    }
}
