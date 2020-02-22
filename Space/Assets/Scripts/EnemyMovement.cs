using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    private enum direction_e
    {
        LEFT = -1,
        RIGHT = 1,
    }

    private Vector2 spawnPos;
    public bool isDead;
    private direction_e enemyDir;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector2(transform.position.x, transform.position.y);
        isDead = true;
        if (Random.Range(0, 10000) % 2 == 0)
            enemyDir = direction_e.LEFT;
        else
            enemyDir = direction_e.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    void moveEnemy()
    {
        Vector3 enemyScale = transform.localScale;

        transform.Translate((int)enemyDir * Time.deltaTime * speed, 0, 0);
        if (enemyScale.x * (int)enemyDir > 0)
            enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Half-turn"))
        {
            int dir = (int)enemyDir * -1;
            enemyDir = (direction_e)dir;
        }
    }
}
