using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<UsugiPlayer>().Stun();
            Destroy(this.gameObject);
        }
    }
}
