using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 苗木と障害物を生成
/// </summary>
public class InstantiateObj : MonoBehaviour
{
    [Header("障害物の生成場所の限界")]
    [SerializeField] Vector3 _rightLimit;
    [SerializeField] Vector3 _leftLimit;
    
    [Header("木の生成場所の限界")]
    [SerializeField] Vector3 _rightLimitForTree;
    [SerializeField] Vector3 _leftLimitForTree;

    [Header("生成オブジェクト")]
    [SerializeField] GameObject _tree;
    [SerializeField] GameObject _obstacleObj;

    [SerializeField] UsugiGameManager _manager;

    [SerializeField] float _obstacleObjCooltiem;
    [SerializeField] float _treeCooltime;
    bool _instantiate = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(InstantiateObstacle));
        StartCoroutine(nameof(InstantiateTree));
    }


    /// <summary>
    /// 障害物の生成
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateObstacle()
    {
        while(true)
        {
            yield return new WaitForSeconds(_obstacleObjCooltiem);
            Instantiate(_obstacleObj, RandomPosForObstacle(), Quaternion.identity);
        }
    }

    /// <summary>
    /// 制限された位置の中でランダムな位置を返す（障害物）
    /// </summary>
    /// <returns></returns>
    Vector3 RandomPosForObstacle()
    {
        Vector3 pos = new Vector3(Random.Range(_rightLimit.x, _leftLimit.x), _rightLimit.y, -1);
        return pos;
    }

    /// <summary>
    /// 木の生成
    /// </summary>
    /// <returns></returns>
    IEnumerator InstantiateTree()
    {
        while (true)
        {
            yield return new WaitForSeconds(_treeCooltime);
            GameObject tree = Instantiate(_tree, RandomPosForTree(), Quaternion.identity);
            tree.GetComponent<Tree>().Manager = _manager;
        }
    }

    /// <summary>
    /// 制限された位置の中でランダムな位置を返す（木）
    /// </summary>
    /// <returns></returns>
    Vector3 RandomPosForTree()
    {
        Vector3 pos = new Vector3(Random.Range(_rightLimitForTree.x, _leftLimitForTree.x), _rightLimitForTree.y, -1);
        return pos;
    }
}
