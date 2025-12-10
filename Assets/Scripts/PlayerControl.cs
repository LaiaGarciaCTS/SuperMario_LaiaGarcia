using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5;

    public int direction = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
