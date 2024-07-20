using UnityEngine;

public class Player: MonoBehaviour
{
    public GameObject bullet;
    public GameObject smallEnemy;
    public GameObject enemy;
    public GameObject bigEnemy;
    public GameObject bulletContainer;
    public GameObject enemyContainer;

    public float playerRadius = 0.25f;
    public float speed = 0.05f;
    public int frameCouter = 0;

    public int framesSinceHit = 0;

    void Update()
    {
        if (framesSinceHit > 0)
        {
            framesSinceHit--;
        }

        frameCouter = frameCouter + 1;

        if (Input.GetKey(KeyCode.W) && transform.position.y < 5 - playerRadius)
        {
            transform.position = transform.position + Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -5 + playerRadius)
        {
            transform.position = transform.position + Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8 + playerRadius)
        {
            transform.position = transform.position + Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 8 - playerRadius)
        {
            transform.position = transform.position + Vector3.right * speed;
        }

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) -  transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle * 180.0f/3.14159f);

        if (frameCouter % 15 == 0)
        {
            var newBullet = Instantiate(bullet, transform.GetChild(0).transform.position, Quaternion.identity).GetComponent<BulletMovement>();
            diff.z = 0;
            newBullet.direction = Vector3.Normalize(diff);
            newBullet.transform.rotation = transform.rotation;
            newBullet.transform.parent = bulletContainer.transform;      
        
        }

        foreach (Transform enemy in enemyContainer.transform)
        {
            if (framesSinceHit == 0 && EnemyNearby(enemy))
            {
                framesSinceHit = 20;
                Destroy(enemy.gameObject);
                EventManager.PlayerDamaged(1);
            }
        }
    }
    public bool EnemyNearby(Transform enemy)
    {
        float distance = Vector3.Distance(transform.position, enemy.position);
        bool nearby = distance < 0.25f;
        return nearby;
    }
}
