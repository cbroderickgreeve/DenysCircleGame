using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public GameObject bulletContainer;
    public GameObject player;

    public float bigEnemySpeed = 0.015f;
    public int bigEnemyHealth = 2;

    void Start()
    {
        bulletContainer = FindObjectOfType<Player>().bulletContainer;
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = Vector3.Normalize(direction);
        transform.position = transform.position + direction * bigEnemySpeed;


        foreach (Transform bullet in bulletContainer.transform)
        {
            if (BulletNearby(bullet))
            {
                bigEnemyHealth = bigEnemyHealth - 1;
                if (bigEnemyHealth == 0) {
                    EventManager.IncreaseSore(2);
                    Destroy(this.gameObject);
                }
                
            }
        }
    }

    public bool BulletNearby(Transform bullet)
    {
        float distance = Vector3.Distance(transform.position, bullet.position);
        bool nearby = distance < 0.6f;
        if (nearby) {
            Destroy(bullet.gameObject);
        }
        return nearby;
    }
}
