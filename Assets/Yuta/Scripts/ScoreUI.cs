using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    [Header("リザルト画面のパネル")]
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
        _scoreText.text =  "合計スコア:" + _score.ToString();
    }
}
