using _Project.Scripts.CameraShake.CameraShakerFSM;
using _Project.Scripts.Core;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public CameraShakePresetSO shakePresetSo;
    public CameraShakerFSM Fsm { get; private set; }
    public CameraShakePresetSO.CameraShakeProperties Preset { get; private set; }
    [SerializeField] private Vector3 positionOffset, rotationOffset;
    
    internal Vector3 Amount { get; set; }
    internal float Tick { get; set; }
    internal bool StartShaking { get; set; }
    
    private bool _isPresetNull;
    
    private void Awake()
    {
        _isPresetNull = shakePresetSo == null;
        if (_isPresetNull)
        {
            Debug.LogError("Camera shake preset is null");
            return;
        }
        SetProperties(ref shakePresetSo.properties);
        Fsm = new CameraShakerFSM();
        Tick = Random.Range(-100f, 100f);
    }

    private void OnValidate()
    {
        _isPresetNull = shakePresetSo == null;
        if (!_isPresetNull && Application.isPlaying)
        {
            SetProperties(ref shakePresetSo.properties);
        }
    }
    
    private void SetProperties(ref CameraShakePresetSO.CameraShakeProperties preset)
    {
        Preset = preset;
        _isPresetNull = false;
    }

    private void Update()
    {
        if (_isPresetNull) return;
        
        Fsm.UpdateFsm(this);
        
        transform.localPosition = Utilities.ElementWiseMultiply(Amount, Preset.positionInfluence) + positionOffset;
        transform.localEulerAngles = Utilities.ElementWiseMultiply(Amount, Preset.rotationInfluence) + rotationOffset;
    }
    
    public void BeginShaking() => StartShaking = true;
}