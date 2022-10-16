using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    [Header("���U���g��ʂ̃p�l��")]
    Image _resultPanel;

    [SerializeField]
    int _score;

    [SerializeField]
    Text _scoreText;

    public void Awake()
    {
        _resultPanel.gameObject.SetActive(false);
    }

    public void ChangeText(float _score)
    {
        _scoreText.text =  "���v�X�R�A:" + _score.ToString();
    }
}
