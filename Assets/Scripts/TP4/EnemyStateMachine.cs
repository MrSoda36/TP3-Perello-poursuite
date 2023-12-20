using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    BaseState initialState;
    BaseState currentState;

    public PursuitState pursuitState { get; private set; } = new PursuitState();
    public PatrolState patrolState { get; private set; } = new PatrolState();
    public ChatState chatState { get; private set; } = new ChatState();
    public AlertState alertState { get; private set; } = new AlertState();

    public NavMeshAgent agent { get; private set; }

    public Waypoint[] waypoints;
    public Waypoint[] doneWaypoints;

    public GameObject player;
    public PlayerController playerController { get; private set; }

    public GameObject chatGuard;

    private void Start() {
        playerController = player.GetComponent<PlayerController>();
        playerController.noiseMade += OnNoiseMade;
        agent = GetComponent<NavMeshAgent>();
        initialState = patrolState;
        currentState = initialState;
        currentState.OnEnterState(this);
    }
    public void SwitchState(BaseState state) {
        currentState.OnExitState(this);
        currentState = state;
        currentState.OnEnterState(this);
    }

    private void Update() {
        currentState.UpdateState(this);
    }

    void OnNoiseMade() {
        SwitchState(alertState);
    }
}
