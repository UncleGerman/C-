using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_maxSpeed = 2f;
    private Animator m_animator;
    private Rigidbody2D m_rigibody;
    private Vector2 Movement;
    [SerializeField] private InventorySystem _inventorySystem;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigibody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        m_animator.SetFloat("Horizontal", MoveX);
        float MoveY = Input.GetAxis("Vertical");
        m_animator.SetFloat("Vertical", MoveY);

        Movement = new Vector2(MoveX * m_maxSpeed, MoveY * m_maxSpeed);
    }
    
    private void FixedUpdate()
    {
        m_rigibody.velocity = Movement;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Item item = collider.GetComponent<Item>();
        if (item.AssetItem == null)
            Debug.Log("Item Data == Null");
        else
        {
            if (_inventorySystem.Inventory.OnEmptyPlace(item.AssetItem))
                Destroy(collider.gameObject);
            else
                Debug.Log("Inventory Full!");
        }
    }
}
