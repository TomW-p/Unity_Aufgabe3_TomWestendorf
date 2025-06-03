using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 2f;   
    private float direction =  0f;
    
    private Rigidbody2D rb;

    [Header("GroundCheck")] 
    [SerializeField] private Transform transformGroundCheck;
    [SerializeField] private LayerMask layerGround;
    
    [Header("Manager")]
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private UIManager uiManager;
    
    private bool canMove = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            direction = 0f;

            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(x:0, y:jumpForce);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            
            //consumeblesManager.AddCoin();
        } else if (other.CompareTag("Obstacle"))
        {
            //uiManager.ShowPanelLost();
            canMove = false;
        }
        
    }
}