using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField]
    [Header("説明用のキャンバス")]
    Canvas _descriptionCanvas;

    [SerializeField]
    [Header("タイトル画面")]
    Canvas _nomalCanvas;

    private void Awake()
    {
        _descriptionCanvas.enabled = false;
        _nomalCanvas.enabled = true;
    }

    public void OnDescription()
    {
        _descriptionCanvas.enabled = true;
        _nomalCanvas.enabled = false;
    }

    public void Return()
    {
        _descriptionCanvas.enabled = false;
        _nomalCanvas.enabled = true;
    }
}
