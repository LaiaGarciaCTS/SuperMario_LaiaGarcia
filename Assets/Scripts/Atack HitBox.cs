using UnityEngine;

public class AtackHitBox : MonoBehaviour
{
    public int attackDamage = 3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer ==7)
        {
            Goomba enemyScript = collider.gameObject.GetComponent<Goomba>();
            enemyScript.TakeDamage(attackDamage);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
