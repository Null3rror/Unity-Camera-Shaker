using _Project.Scripts.CameraShake.CameraShakerFSM.CameraShakeStates;
using _Project.Scripts.Core.FSM;
using _Project.Scripts.Core.Fsm.CoreStates;

namespace _Project.Scripts.CameraShake.CameraShakerFSM
{
    public class CameraShakerFSM : FSM<CameraShaker>
    {
        public State<CameraShaker> Idle { get; private set; }
        public State<CameraShaker> FadeIn { get; private set; }
        public State<CameraShaker> Shake { get; private set; }
        public State<CameraShaker> FadeOut { get; private set; }

        public CameraShakerFSM()
        {
            InitStates();
        }

        protected sealed override void InitStates()
        {
            Idle = new CameraShakeIdleState();
            FadeIn = new CameraShakeFadeInState(0f);
            Shake = new CameraShakeShakeState(0f);
            FadeOut = new CameraShakeFadeOutState(0f);
            State = Idle;
        }
    }
}
