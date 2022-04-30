using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraShakePreset", menuName = "Camera Shake Preset")]
public class CameraShakePresetSO : ScriptableObject
{
    [Serializable]
    public struct CameraShakeProperties
    {
        [Min(0f)]
        public float fadeInTime, shakeTime, fadeOutTime;
        [Tooltip("Intensity of the shake")]
        public float magnitude;
        [Tooltip("Perlin Noise is used for creating random values.\nRoughness of the shake defines how fast or slow it changes values,\nlower values are smoother(smaller changes) while higher values are jarring(big jumps & changes)")]
        public float roughness;

        public Vector3 positionInfluence, rotationInfluence;
    }

    [SerializeField] 
    public CameraShakeProperties properties;
}