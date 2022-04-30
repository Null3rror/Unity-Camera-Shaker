using _Project.Scripts.Core;
using _Project.Scripts.Core.Fsm.CoreStates;
using UnityEngine;

namespace _Project.Scripts.CameraShake.CameraShakerFSM.CameraShakeStates
{
    public class CameraShakeShakeState : TimedState<CameraShaker>
    {
        private float _roughness, _magnitude;
        public CameraShakeShakeState(float time) : base(time)
        {
        }

        public override void OnEnter(CameraShaker cameraShaker)
        {
            time = cameraShaker.Preset.shakeTime;
            _roughness = cameraShaker.Preset.roughness;
            _magnitude = cameraShaker.Preset.magnitude;
            base.OnEnter(cameraShaker);
        }

        public override void Update(CameraShaker cameraShaker)
        {
            if (time == 0f) return;
        
            Vector3 amount = Utilities.RandomPerlinVector3(cameraShaker.Tick);

            cameraShaker.Tick += UnityEngine.Time.deltaTime * _roughness;
            cameraShaker.Amount = amount * _magnitude;
        }

        public override State<CameraShaker> DetermineNextState(CameraShaker t) => 
            IsOverTime() ? t.Fsm.FadeOut : base.DetermineNextState(t);
    }
}