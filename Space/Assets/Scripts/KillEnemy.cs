using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [HideInInspector]
    public CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillZone")) {
            if (GetComponent<Skills>().invicibility || collision.gameObject.GetComponentInParent<EnemyMovement>().isInvicible)
                return;
            collision.gameObject.GetComponentInParent<EnemyMovement>().hp -= 1;
            if (collision.gameObject.GetComponentInParent<EnemyMovement>().hp != 0) {
                collision.gameObject.GetComponentInParent<EnemyMovement>().setInvicibility();
                return;
            }
            if (collision.gameObject.GetComponentInParent<EnemyMovement>().giveXP)
                GetComponent<Skills>().LevelUp();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponentInParent<EnemyMovement>().isDead = true;
            collision.gameObject.GetComponentInParent<EnemyMovement>().giveXP = false;
            collision.gameObject.GetComponentInParent<Animator>().SetBool("IsDead", true);
            GetComponentInParent<Movement>().isJumping = true;
            controller.soundPlayer.PlaySound(2);
        }
    }
}
