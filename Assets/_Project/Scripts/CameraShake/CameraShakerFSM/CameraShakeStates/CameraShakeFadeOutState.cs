using _Project.Scripts.Core;
using _Project.Scripts.Core.Fsm.CoreStates;
using UnityEngine;

namespace _Project.Scripts.CameraShake.CameraShakerFSM.CameraShakeStates
{
    public class CameraShakeFadeOutState : TimedState<CameraShaker>
    {
        private float _roughness, _magnitude;
        public CameraShakeFadeOutState(float time) : base(time)
        {
        }

        public override void OnEnter(CameraShaker cameraShaker)
        {
            time = cameraShaker.Preset.fadeOutTime;
            _roughness = cameraShaker.Preset.roughness;
            _magnitude = cameraShaker.Preset.magnitude;
            base.OnEnter(cameraShaker);
        }

        public override void Update(CameraShaker cameraShaker)
        {
            if (time == 0f) return;
        
            Vector3 amount = Utilities.RandomPerlinVector3(cameraShaker.Tick);

            cameraShaker.Tick += UnityEngine.Time.deltaTime * _roughness * (1f - NormalizedElapsedTime());
            cameraShaker.Amount = amount * ((1f - NormalizedElapsedTime()) * _magnitude);
        }

        public override State<CameraShaker> DetermineNextState(CameraShaker cameraShaker)
        {
            return IsOverTime() ? cameraShaker.Fsm.Idle : base.DetermineNextState(cameraShaker);
        }
    }
}