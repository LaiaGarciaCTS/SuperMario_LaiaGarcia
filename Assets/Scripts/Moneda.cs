using UnityEngine;

public class Moneda : MonoBehaviour
{

//animación moneda
    public Animator monedaAnimator;

    public Rigidbody2D rigidbodyMoneda;


    private AudioSource _audioSourceMoneda;
    public AudioClip monedaSonido;

    public GameManager _gameManager;

    void Awake()
    {
        monedaAnimator = GetComponent<Animator>();

        rigidbodyMoneda = GetComponent<Rigidbody2D>();

        _audioSourceMoneda = GetComponent<AudioSource>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D monedaCollision)
    {
        if (monedaCollision.gameObject.CompareTag("Player"))
        {
            _audioSourceMoneda.PlayOneShot(monedaSonido);
            _gameManager.CoinCounter();
           Destroy(gameObject, 0.3f);
           
        }
    }

}