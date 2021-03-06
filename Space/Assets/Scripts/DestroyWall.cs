﻿using System.Collections;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 && skill.currentLevel >= WallLvl)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            player.GetComponent<CharacterController2D>().soundPlayer.PlaySound(3);
        }
    }
}
