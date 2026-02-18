using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    PlayerControl _playerScript;


    public BoxCollider2D deathZone;

    void Awake()
    {
        _playerScript = GetComponentInParent<PlayerControl>();
        deathZone = GameObject.Find("Death Zone").GetComponent<BoxCollider2D>();
    }


    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }

        if(collision.gameObject.layer == 7)
        {
            //Destroy(collision.gameObject);
            _playerScript.Bounce();
            Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
            _enemyScript.TakeDamage();
        }

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            StartCoroutine(_playerScript.MarioDeath());
            _playerScript.Bounce();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }
}