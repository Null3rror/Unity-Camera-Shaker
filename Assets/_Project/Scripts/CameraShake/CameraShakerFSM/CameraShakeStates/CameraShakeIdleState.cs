using _Project.Scripts.Core.Fsm.CoreStates;
using UnityEngine;

namespace _Project.Scripts.CameraShake.CameraShakerFSM.CameraShakeStates
{
    public class CameraShakeIdleState : State<CameraShaker>
    {
        public override void OnEnter(CameraShaker cameraShaker)
        {
            cameraShaker.StartShaking = false;
        }
        public override void OnExit(CameraShaker cameraShaker)
        {
            cameraShaker.StartShaking = false;
        }

        public override void Update(CameraShaker cameraShaker)
        {
            cameraShaker.Amount = Vector3.zero;
        }

        public override State<CameraShaker> DetermineNextState(CameraShaker cameraShaker)
        {
            return cameraShaker.StartShaking ? cameraShaker.Fsm.FadeIn : base.DetermineNextState(cameraShaker);
        }
    }
}