using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Vector3 startPosition;
    public float movementSpeed = 5;
    public int direction = 5;

    private InputAction moveAction;
    private Vector2 moveDirection;
    private InputAction jumpAction;


    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;

    public float jumpForce = 10;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
 
        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
        transform.position = startPosition;

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        
        transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

    //otras maneras de hacer que el personaje se mueva de lado a lado en eje X.
        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));

        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + moveDirection.x, transform.position.y), movementSpeed * Time.deltaTime);


    //Cómo hacer flip al moverse.
        if(moveDirection.x > 0)
        {
            renderer.flipX = false;
        }

        else if(moveDirection.x < 0)
        {
            renderer.flipX = true;
        }
    
    //cómo saltar pulsando un botón.
        if(jumpAction.WasPressedThisFrame())
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
       
    //cómo eliminar la fracción.
       void FixedUpdate()
       {
            rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
       }
    }
}