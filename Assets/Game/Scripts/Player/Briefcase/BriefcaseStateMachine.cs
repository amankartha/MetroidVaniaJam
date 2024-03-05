
    public class BriefcaseStateMachine
    {
        public BriefcaseState CurrentState { get; private set; }

        public void Initialize(BriefcaseState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(BriefcaseState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
