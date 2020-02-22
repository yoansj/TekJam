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

    private direction_e enemyDir;
    private Vector3 enemyPos;
    private Vector3 enemyScale;


    // Start is called before the first frame update
    void Start()
    {
        enemyPos = transform.position;
        enemyScale = transform.localScale;
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
        Vector3 enemyPos = transform.position;
        Vector3 enemyScale = transform.localScale;

        enemyPos.x += (float)enemyDir / 10;
        transform.position = enemyPos;
        if (enemyScale.x * (int)enemyDir < 0)
            enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VerticalWall")
        {
            int dir = (int)enemyDir * -1;
            enemyDir = (direction_e)dir;
            print("Yes");
        } else
        {
            print("no");
        }
/*            Vector3 hit = collision.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.forward);

            if (Mathf.Approximately(angle, 0))
            { // top
                Destroy(collision.gameObject);
                speedZ = -speedZ;
            }
            if (Mathf.Approximately(angle, 180))
            { // bottom
                Destroy(collision.gameObject);
                speedZ = -speedZ;
            }
            if (Mathf.Approximately(angle, 90))
            {
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                if (cross.y > 0)
                { // right
                    Destroy(collision.gameObject);
                    speedX = -speedX;
                }
                else
                { // left
                    Destroy(collision.gameObject);
                    speedX = -speedX;
                }
            }
*/
    }
}
