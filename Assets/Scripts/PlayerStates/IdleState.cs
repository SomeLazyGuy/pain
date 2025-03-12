using UnityEngine;

public class IdleState : State {
    public override void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Idle_Entry");
    }

    public override void Update() {
        
    }

    public override void Exit() {
        Debug.Log("Idle_Exit");
    }
}