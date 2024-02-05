using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
        Input.Movement.MoveModeSwitch.started += OnMovingStateSwitchpressed;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
        Input.Movement.MoveModeSwitch.started -= OnMovingStateSwitchpressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();

    private void OnMovingStateSwitchpressed(InputAction.CallbackContext obj) 
    {
        Data.IsWalking = !Data.IsWalking;

        if (Data.IsWalking)
            StateSwitcher.SwitchState<WalkingState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }
}