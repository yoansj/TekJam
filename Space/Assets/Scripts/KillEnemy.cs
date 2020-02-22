using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillZone")) {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponentsInParent<BoxCollider2D>()[1].enabled = false;
            GetComponentInParent<Movement>().isJumping = true;
            GetComponent<Skills>().LevelUp();
        }
    }
}
