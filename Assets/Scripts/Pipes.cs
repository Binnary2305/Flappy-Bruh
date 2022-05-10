
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;

    public float leftEdge;
    
    private void Update()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;

        transform.position += Vector3.left * speed *Time.deltaTime;

        if(transform.position.x<leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
