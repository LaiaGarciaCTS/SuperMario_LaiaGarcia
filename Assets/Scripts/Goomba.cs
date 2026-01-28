using UnityEngine;

public class Goomba : MonoBehaviour

{
    // Variable para la animación de Goomba
    public Animator goombaAnimator;

    // Variable para la velocidad y la dirección
    public float movementSpeed = 5;
    public int direction = 1;

    //sonido cuando muere
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;

    public AudioClip deathSFX;




    void Awake()
    {
        goombaAnimator = GetComponent<Animator>();

        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GetComponent<GameManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction > 0)
        {
            goombaAnimator.SetBool("Walk", true);
        }
        else if(direction > 0)
        {
            goombaAnimator.SetBool("Walk", false);
        }
        else
        {
            goombaAnimator.SetBool("Walk", false);
        }   
    }
    
    void FixedUpdate()
    {
        _rigidBody2D.linearVelocity = new Vector2(direction * movementSpeed, _rigidBody2D.linearVelocity.y);
    }

    // Para cuando se choque que gire
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tuberias") || collision.gameObject.layer == 7)
        {
            direction = direction * -1;
            //Esto hace lo mismo direction *= -1;
        }
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }


    public void GoombaDeath()
    {
        _boxCollider.enabled = false;
        
        goombaAnimator.SetBool("Goomba death", true);

        _gameManager.AddKill();

        _audioSource.PlayOneShot(deathSFX);

        movementSpeed = 0;

        

        Destroy(gameObject, 1.2f);

    //_audioSource.clip = deathSFX
    //_audioSource.Play();
}
}