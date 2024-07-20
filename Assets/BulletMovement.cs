using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;
    public float bulletSpeed = 5f;
    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = transform.position + direction * bulletSpeed * Time.deltaTime;

        if (transform.position.x >= 8 || transform.position.x <= -8) {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 5 || transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
    }
}
