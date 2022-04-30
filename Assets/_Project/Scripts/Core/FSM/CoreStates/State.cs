namespace _Project.Scripts.Core.Fsm.CoreStates
{
    public abstract class State<T> where T : class
    {
        public virtual void OnEnter(T t)
        {
            Logger.Debug("Entering " + GetType().Name);
        }

        public virtual void OnExit(T t)
        {
            Logger.Debug("Exiting " + GetType().Name);
        }

        public abstract void Update(T t);

        public virtual State<T> DetermineNextState(T t) => null;
    }
}