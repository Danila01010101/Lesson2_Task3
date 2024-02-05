public class RunningSpeedUpState : GroundedState
{
    private readonly RunningSpeedUpConfig _config;

    public RunningSpeedUpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningSpeedUpConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (IsRunningOver())
            StateSwitcher.SwitchState<RunningState>();
    }

    private bool IsRunningOver() => Input.Movement.SpeedUp.ReadValue<float>() == 0;
}