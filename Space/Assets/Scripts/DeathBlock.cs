using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBlock : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        SceneManager.LoadScene(2);
    }
}
