using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField]
    [Header("�����p�̃L�����o�X")]
    Canvas _descriptionCanvas;

    [SerializeField]
    [Header("�^�C�g�����")]
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
