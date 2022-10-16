using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ono : MonoBehaviour
{
    [SerializeField] List<GameObject> _trees = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Tree>() == true)
        {
            _trees.Add(collision.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _trees.Remove(collision.gameObject);
    }

    public void Cut()
    {
        foreach (var item in _trees)
        {
            item.GetComponent<Tree>().Cut();
        }
    }
}
