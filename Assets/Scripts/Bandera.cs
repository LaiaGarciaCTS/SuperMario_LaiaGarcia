using UnityEngine;

public class Bandera : MonoBehaviour
{

    public GameManager _gameManager;
    public BoxCollider2D _boxCollider;
   


    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            StartCoroutine(_gameManager.Win());
        }
        

    }
}
