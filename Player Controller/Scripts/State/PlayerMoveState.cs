using UnityEngine;

public class PlayerMoveState : State
{
    public delegate void EventMove();
    public event EventMove HorizontalMove;
    public event EventMove VerticalMove;

    public PlayerMovementEvent PlayerMovementEvent { private get; set; }

    public override void Enter()
    {
        if (PlayerMovementEvent is null)
        {
            throw new System.ArgumentNullException(nameof(PlayerMovementEvent));
        }
        else
        {
            PlayerMovementEvent.EnterEvent();
        }
    }

    public override void Exit()
    {
        if (PlayerMovementEvent is null)
        {
            throw new System.ArgumentNullException(nameof(PlayerMovementEvent));
        }
        else
        {
            PlayerMovementEvent.ExitEvent();
        }
    }

    public override void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            HorizontalMove.Invoke();
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            VerticalMove.Invoke();
        }
    }
}
