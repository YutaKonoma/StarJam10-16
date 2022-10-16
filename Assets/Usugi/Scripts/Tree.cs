using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] Sprite _tree1;
    [SerializeField] Sprite _tree2;
    [SerializeField] Sprite _deadTree;
    [SerializeField] SpriteRenderer _treeRenderer;

    [SerializeField] bool _grow1;
    [SerializeField] bool _grow2;
    [SerializeField] UsugiGameManager _manager;
    public UsugiGameManager Manager { set => _manager = value; }
    [SerializeField] float _point;
    [SerializeField] float _deadTime;

    private void Start()
    {
        StartCoroutine(nameof(Deading));
    }

    IEnumerator Deading()
    {
        yield return new WaitForSeconds(_deadTime);
        Destroy(this.gameObject);
    }

    public void Grow()
    {
        if(_grow1 != true)
        {
            _grow1 = true;
            _treeRenderer.sprite = _tree1;
            StopCoroutine(nameof(Deading));
            StartCoroutine(nameof(Deading));
        }
        else if(_grow1 == true)
        {
            _grow2 = true;
            _treeRenderer.sprite = _tree2;
            StopCoroutine(nameof(Deading));
            StartCoroutine(nameof(Deading));
        }
    }

    public void Cut()
    {
        if(_grow2 == true)
        {
            _manager.AddScore(_point);
            Destroy(this.gameObject);
        }
    }
}
