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
    public bool isAwake;
    private direction_e enemyDir;
    public float speed;

    private BoxCollider2D box;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponentsInChildren<BoxCollider2D>()[1];
        animator = GetComponent<Animator>();
        spawnPos = new Vector2(transform.position.x, transform.position.y);
        isDead = false;
        if (Random.Range(0, 10000) % 2 == 0)
            enemyDir = direction_e.LEFT;
        else
            enemyDir = direction_e.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
        respawn();
    }

    void moveEnemy()
    {
        Vector3 enemyScale = transform.localScale;

        if (!isDead)
            transform.Translate((int)enemyDir * Time.deltaTime * speed, 0, 0);
        if (enemyScale.x * (int)enemyDir > 0)
            enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    void respawn()
    {
        if (isAwake) {
            box.enabled = true;
            isAwake = false;
            isDead = false;
            animator.SetBool("IsDead", false);
        }
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
