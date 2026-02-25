using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControl : MonoBehaviour

{
    public Vector3 startPosition;
    public float movementSpeed = 5;
    public int direction = 5;

    private InputAction moveAction;
    private Vector2 moveDirection;
    private InputAction jumpAction;
    private InputAction _pauseAction;
    public float bounceForce = 4;
    private GameManager _gameManager;
    private BGMManager _bgmManagerScript;
    private BoxCollider2D _boxCollider;
    private AudioClip deathSFXMario;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;
    private GroundSensor sensor;

    private Animator animator;

    private AudioSource _audioSourceSalto;
    public AudioClip saltoSonido;

    public AudioClip win;
    
    public float jumpForce = 10;


    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>();
        animator = GetComponent<Animator>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _boxCollider = GetComponent<BoxCollider2D>();

        _audioSourceSalto = GetComponent<AudioSource>();
        deathSFXMario = GetComponent<AudioClip>();

        _bgmManagerScript = GameObject.Find ("BGM Manager").GetComponent<BGMManager>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
        _pauseAction = InputSystem.actions["Pause"];
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
        if(_pauseAction.WasPressedThisFrame())
        {
            _gameManager.Pause();
        }

        if(_gameManager._pause == true)
        {
            return;
        }

        moveDirection = moveAction.ReadValue<Vector2>();
        
        transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

    //otras maneras de hacer que el personaje se mueva de lado a lado en eje X.
        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));

        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + moveDirection.x, transform.position.y), movementSpeed * Time.deltaTime);


    //Cómo hacer flip al moverse y hacer la animación de correr
        if(moveDirection.x > 0)
        {
            renderer.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if(moveDirection.x < 0)
        {
            renderer.flipX = true;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    
    //cómo saltar pulsando un botón.
        if(jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _audioSourceSalto.PlayOneShot(saltoSonido);
        }
        
        

        animator.SetBool("IsJumping", !sensor.isGrounded);
       
    //cómo eliminar la fricción.
       
    }
    void FixedUpdate()
       {
            rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
       }

    public void Bounce()
    {
        rBody2D.linearVelocity = new Vector2(rBody2D.linearVelocity.x,0);
        rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Win")
        {
            _bgmManagerScript.Win();
            _audioSourceSalto.PlayOneShot(win);
        }
    }

    public IEnumerator MarioDeath()
    {
        _boxCollider.enabled = false;
        _bgmManagerScript.StopBGM();
        animator.SetBool("IsDeath", true);
        _audioSourceSalto.PlayOneShot(deathSFXMario);
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
        
        _gameManager.GameOver();
    }






    
}