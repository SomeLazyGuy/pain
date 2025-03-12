using UnityEngine;
public class GroundPoundState : State {
    private PlayerStateMachine _stateMachine;

    public override void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("GroundPound_Entry");
        _stateMachine = stateMachine;
    }

    public override void Update() { }

    public override void Exit() {
        Debug.Log("GroundPound_Exit");
    }
}
