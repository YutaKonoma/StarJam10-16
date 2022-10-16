using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームマネージャーのコンポーネント
/// 機能
/// スコアカウント
/// 
/// </summary>
public class UsugiGameManager : MonoBehaviour
{
    [SerializeField] float _timeLimit;
     public static float  _score;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _timerText;
    [SerializeField] string _gameScene;
    // Start is called before the first frame update


    private void Start()
    {
        _score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        _scoreText.text = $"SCORE : {_score}";

        _timeLimit -= Time.deltaTime;
        _timerText.text = $"TIME : {_timeLimit:F2}" ;

        if(_timeLimit < 0)
        {
            SceneManager.LoadScene(_gameScene);
        }
    }

    public void AddScore(float point)
    {
        _score += point;
        
    }
}
