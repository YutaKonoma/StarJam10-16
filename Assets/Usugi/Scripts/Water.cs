using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Tree")
        {
            collision.GetComponent<Tree>().Grow();
            Destroy(this.gameObject);
        }
    }
}
