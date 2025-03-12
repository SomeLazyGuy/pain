using UnityEngine;

public class IdleState : IState {
    public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("Idle_Entry");
    }

    public void Update() {
        
    }

    public void Exit() {
        Debug.Log("Idle_Exit");
    }
}