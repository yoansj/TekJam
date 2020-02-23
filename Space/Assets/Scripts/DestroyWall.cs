using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    private GameObject player;
    private Skills skill;
    public GameObject explosion;

    public int WallLvl = 3;

    private void Start()
    {
        player = GameObject.Find("Player");
        skill = player.GetComponent<Skills>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0 && skill.currentLevel == WallLvl)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
        
    }
}
