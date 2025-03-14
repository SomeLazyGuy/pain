using System;
using TMPro;
using UnityEngine;

public class SwitchStateText : MonoBehaviour {
    private TextMeshProUGUI _textMesh;
    private PlayerStateMachine _stateMachine;
    
    private void Start() {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _stateMachine = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
        _stateMachine.switchStateEvent.AddListener(UpdateStateText);
    }

    private void OnDisable() {
        _stateMachine.switchStateEvent.RemoveListener(UpdateStateText);
    }

    private void UpdateStateText(String state) {
        _textMesh.text = state;
    }
}
