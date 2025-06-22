using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    
    private bool canMove = false;
    
    void Start()
    {
        //hier holen wir uns die infos vom Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //wenn canMove true ist dann wird löst das alles hier drin aus
        if (canMove)
        {
            //bewegung 0
            direction = 0f;
            //a wurde gedrückt? geh nach rechts
            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }
            //d wurde gedrückt? geh nach links
            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }
            //spaceBar wurde gedrückt? spring
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }
            //
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    //hier wird das Movment an geschalten
    public void SetMovementTrue()
    {
             canMove = true;
    }
    //und hier wirds ausgeschalten
    public void SetMovementFalse()
    {
        canMove = false;
    }
    
    //hier ist die Funktion zum Springen
    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(x:0, y:jumpForce);
        }
    }
    
    //hier wird gecheckt ob man mit einem Collider2D collidiert
    private void OnTriggerEnter2D(Collider2D other)
    {
        //hir wird jetzt immer gefragt ob das Objekt mit dem wir collidiert sind einen Tag hat
        //wenn es einer vann den Tags ist wir die jeweilige Schleife ausgelöst
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            
            itemManager.AddCoin();
        }else if (other.CompareTag("Coin2"))
        {
            Destroy(other.gameObject);
            
            itemManager.AddBigCoin();
        }
        else if (other.CompareTag("FinischPoint"))
        {
            SceneController.instance.NextLevel();
        }
        else if (other.CompareTag("Obstacle"))
        {
            uiManager.ShowPanelLost();
            SetMovementFalse();
        }
    }
}