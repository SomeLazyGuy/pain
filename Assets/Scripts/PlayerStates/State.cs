public abstract class State {
    public abstract void Entry(PlayerStateMachine stateMachine);
    public abstract void Update();
    public abstract void Exit();
}