using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    float _score;

    [SerializeField]
    Text _scoreText;

    public void Awake()
    {
        _score = UsugiGameManager._score;
        _scoreText.text = "合計スコア:" + _score.ToString();
    }

    public void ChangeText()
    {
        _score = UsugiGameManager._score;
        _scoreText.text =  "合計スコア:" + _score.ToString();
    }
}
