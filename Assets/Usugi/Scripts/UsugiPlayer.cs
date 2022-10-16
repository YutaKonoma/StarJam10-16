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
    [SerializeField] GameObject _hitEffect;
    [SerializeField] Animator _animator;

    [Header("音")]
    [SerializeField] AudioClip _waterSound;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _footStep;
    [SerializeField] AudioClip _cutSound;
    [SerializeField] AudioSource _footSource;

    [SerializeField] float _inputY;
    [SerializeField] float _footSoundTimer;
    float _inputWheel;
    bool _watering = true;
    bool _cutting = false;
    bool _main = true;
    bool _stun;
    bool _foot;

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        //FootSound();

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
            _audioSource.PlayOneShot(_waterSound);
        }
    }

    public void Stun()
    {
        _stun = true;
        StartCoroutine(nameof(StunCoolTime));
    }

    IEnumerator StunCoolTime()
    {
        _hitEffect.SetActive(true);
        _animator.SetBool("stun", true);
        yield return new WaitForSeconds(_stunTime);
        _hitEffect.SetActive(false);
        _animator.SetBool("stun", false);
        _stun = false;
    }

    void CutTree()
    {
        if(_cutting)
        {
            _audioSource.PlayOneShot(_cutSound);
            _onoScripts.Cut();
        }
    }

    void FootSound()
    {
        if (_inputY == 0)
        {
            _footSource.Stop();
            return;
        }

        if (_foot)
        {
            return;
        }

        if(_inputY != 0)
        {
            PlayFootstepSound();
        }

        StartCoroutine(nameof(FootstepTimer));

    }

    void PlayFootstepSound()
    {
        _footSource.PlayOneShot(_footStep);
    }

    IEnumerator FootstepTimer()
    {
        _foot = true;
        yield return new WaitForSeconds(1);
        _foot = false;
    }

}
