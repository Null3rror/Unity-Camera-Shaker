using _Project.Scripts.Core.Fsm.CoreStates;

namespace _Project.Scripts.Core.FSM
{
    public abstract class FSM<T> where T : class
    {
        protected State<T> State;
        

        private void DetermineNextState(T t)
        {
            State<T> nextState = State?.DetermineNextState(t);
            if (nextState == null) return; // dont change state
            State.OnExit(t);
            State = nextState;
            State.OnEnter(t);
        }

        protected abstract void InitStates();


        public void UpdateFsm(T t)
        {
            DetermineNextState(t);
            State?.Update(t);
        }
    }
}
