using UnityEngine;

public sealed class PlayerMovementEvent : IEvent
{
    private readonly Animator _playerAnimator;
    private readonly Rigidbody2D _playerRigidbody2D;
    private readonly PlayerMoveState _playerMoveState;
    private readonly PlayerData _playerData;

    public PlayerMovementEvent(PlayerData playerData, Animator animator, Rigidbody2D rigidbody2D, PlayerMoveState playerMoveState)
    {
        _playerAnimator = animator;
        _playerRigidbody2D = rigidbody2D;
        _playerMoveState = playerMoveState;
        _playerData = playerData;
    }

    public void EnterEvent()
    {
        if (_playerMoveState is null)
        {
            throw new System.ArgumentNullException(nameof(_playerMoveState));
        }
        else
        {
            _playerMoveState.HorizontalMove += MoveHorizontal;
            _playerMoveState.VerticalMove += MoveVertical;
        }
    }

    public void ExitEvent()
    {
        if (_playerMoveState is null)
        {
            throw new System.ArgumentNullException(nameof(_playerMoveState));
        }
        else
        {
            _playerMoveState.HorizontalMove -= MoveHorizontal;
            _playerMoveState.VerticalMove -= MoveVertical;
        }
    }

    private void MoveHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _playerAnimator.SetFloat("Horizontal", horizontal);
        var movePosition = new Vector2(horizontal * _playerData.PlayerSpeed, 0);
        _playerRigidbody2D.velocity = movePosition;
    }

    private void MoveVertical()
    {
        float vertical = Input.GetAxis("Vertical");
        _playerAnimator.SetFloat("Vertical", vertical);
        var movePosition = new Vector2(0, vertical * _playerData.PlayerSpeed);
        _playerRigidbody2D.velocity = movePosition;
    }
}
