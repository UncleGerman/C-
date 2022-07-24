using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_maxSpeed = 2f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigibody;
    private Vector2 Movement;
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private PlayerData _playerData;

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new PlayerIdleState());
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            _rigibody.velocity = default;
            _stateMachine.ChangeState(new PlayerIdleState());
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var playerMoveState = new PlayerMoveState();
            var playerMovementEvent = new PlayerMovementEvent(_playerData, _animator, _rigibody, playerMoveState);
            playerMoveState.PlayerMovementEvent = playerMovementEvent;
            _stateMachine.ChangeState(playerMoveState);
            _stateMachine.CurrentState.Update();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Item item = collider.GetComponent<Item>();

        if (item.AssetItem is null)
        {
            Debug.Log("Item Data == Null");
        } 
        else
        {
            if (_inventoryData.InventoryEventHandler.AddItem(item.AssetItem))
            {
                Destroy(collider.gameObject);
            }
            else
            {
                Debug.Log("Inventory Full!");
            }
        }
    }
}
