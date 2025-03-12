using UnityEngine;
public class GroundPoundState : State {
    
    private PlayerStateMachine _stateMachine;

    override public void Entry(PlayerStateMachine stateMachine) {
        Debug.Log("GroundPound_Entry");

        _stateMachine = stateMachine;

    }

    override public void Update()
    {
        
    }

    override public void Exit() {
        Debug.Log("GroundPound_Exit");
    }
}
