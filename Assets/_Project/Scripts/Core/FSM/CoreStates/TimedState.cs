using UnityEngine;

namespace _Project.Scripts.Core.Fsm.CoreStates
{
    public abstract class TimedState<T> : State<T> where T : class
    {
        protected float time;
        private float _startTime;
        

        protected TimedState(float time)
        {
            this.time = time;
        }

        public override void OnEnter(T t)
        {
            base.OnEnter(t);
            _startTime = UnityEngine.Time.realtimeSinceStartup;
        }

        protected float NormalizedElapsedTime() => time != 0f ? ElapsedTime() / time : Mathf.Infinity;

        protected float ElapsedTime() => UnityEngine.Time.realtimeSinceStartup - _startTime; // TODO: change to Time.time

        protected bool IsOverTime() => ElapsedTime() >= time;
    }
}