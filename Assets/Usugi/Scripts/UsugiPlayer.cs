using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのコンポーネント
/// 
/// 機能
/// 
/// 実装済み
/// 移動
/// 水やり
/// スタン
/// 
/// 未実装
/// 木刈り
/// 水やりと木刈りの切り替え
/// </summary>
public class UsugiPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] GameObject _water;
    [SerializeField] float _stunTime;
    [SerializeField] GameObject _wateringCan;
    [SerializeField] GameObject _onoColider;
    [SerializeField] Ono _onoScripts;

    float _inputY;
    float _inputWheel;
    bool _watering = true;
    bool _cutting = false;
    bool _main = true;
    bool _stun;

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        ChangeWeapon();

        Watering();

        CutTree();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ReadInput()
    {
        _inputY = Input.GetAxisRaw("Horizontal");

        _inputWheel = Input.GetAxisRaw("Mouse ScrollWheel");
        

        if (_main)
        {
            _watering = Input.GetButtonDown("RightClick");
        }
        else
        {
            _cutting = Input.GetButtonDown("RightClick");
        }

    }

    private void ChangeWeapon()
    {
        if (_inputWheel < 0)
        {
            _main = true;
            _wateringCan.SetActive(true);
            _onoColider.SetActive(false);
        }
        else if (_inputWheel > 0)
        {
            _main = false;
            _wateringCan.SetActive(false);
            _onoColider.SetActive(true);
        }
    }

    private void Move()
    {
        if(_stun)
        {
            _rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            _rb.velocity = new Vector3(_inputY * _speed, _rb.velocity.y);
        }
    }

    void Watering()
    {
        if(_watering)
        {
            Instantiate(_water, _wateringCan.transform.position, Quaternion.identity);
        }
    }

    public void Stun()
    {
        _stun = true;
        StartCoroutine(nameof(StunCoolTime));
    }

    IEnumerator StunCoolTime()
    {
        yield return new WaitForSeconds(_stunTime);
        _stun = false;
    }

    void CutTree()
    {
        if(_cutting)
        {
            _onoScripts.Cut();
        }
    }

}
