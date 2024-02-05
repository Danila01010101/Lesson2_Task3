using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    [SerializeField] private RunningSpeedUpConfig _speedUpStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    public RunningSpeedUpConfig RunningSpeedUpConfig => _speedUpStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
}
