public interface IState {
    public void Entry(PlayerStateMachine stateMachine);
    public void Update();
    public void Exit();
}