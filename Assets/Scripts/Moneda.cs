using UnityEngine;

public class Moneda : MonoBehaviour
{

//animación moneda
    public Animator monedaAnimator;

    public Rigidbody2D rigidbodyMoneda;




    void Awake()
    {
        monedaAnimator = GetComponent<Animator>();

        rigidbodyMoneda = GetComponent<Rigidbody2D>();
    }



//contador de monedas + que desaparezca cuando mario colisione con la moneda
    public Collision2D monedaCollision;

    void OnCollisionEnter2D(Collision2D monedaCollision)
    {
        if (monedaCollision.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }

}