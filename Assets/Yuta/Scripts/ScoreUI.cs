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
    float _score;

    [SerializeField]
    Text _scoreText;

    public void Awake()
    {
        _resultPanel.gameObject.SetActive(false);
        _score = UsugiGameManager._score;
        _scoreText.text = "合計スコア:" + _score.ToString();
    }

    public void ChangeText()
    {
        _score = UsugiGameManager._score;
        _scoreText.text =  "合計スコア:" + _score.ToString();
    }
}
