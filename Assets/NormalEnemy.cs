using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public GameObject bulletContainer;
    public GameObject player;

    public float normalEnemySpeed = 0.025f;

    void Start()
    {
        bulletContainer = FindObjectOfType<Player>().bulletContainer;
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = Vector3.Normalize(direction);
        transform.position = transform.position + direction * normalEnemySpeed;


        foreach (Transform bullet in bulletContainer.transform)
        {
            if (BulletNearby(bullet))
            {
                EventManager.IncreaseSore(1);
                Destroy(this.gameObject);
            }
        }
    }

    public bool BulletNearby(Transform bullet)
    {
        float distance = Vector3.Distance(transform.position, bullet.position);
        bool nearby = distance < 0.3f;
        return nearby;
    }
}
