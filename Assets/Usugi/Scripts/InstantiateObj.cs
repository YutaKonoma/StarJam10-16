using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �c�؂Ə�Q���𐶐�
/// </summary>
public class InstantiateObj : MonoBehaviour
{
    [Header("��Q���̐����ꏊ�̌��E")]
    [SerializeField] Vector3 _rightLimit;
    [SerializeField] Vector3 _leftLimit;
    
    [Header("�؂̐����ꏊ�̌��E")]
    [SerializeField] Vector3 _rightLimitForTree;
    [SerializeField] Vector3 _leftLimitForTree;

    [Header("�����I�u�W�F�N�g")]
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
    /// ��Q���̐���
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
    /// �������ꂽ�ʒu�̒��Ń����_���Ȉʒu��Ԃ��i��Q���j
    /// </summary>
    /// <returns></returns>
    Vector3 RandomPosForObstacle()
    {
        Vector3 pos = new Vector3(Random.Range(_rightLimit.x, _leftLimit.x), _rightLimit.y, -1);
        return pos;
    }

    /// <summary>
    /// �؂̐���
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
    /// �������ꂽ�ʒu�̒��Ń����_���Ȉʒu��Ԃ��i�؁j
    /// </summary>
    /// <returns></returns>
    Vector3 RandomPosForTree()
    {
        Vector3 pos = new Vector3(Random.Range(_rightLimitForTree.x, _leftLimitForTree.x), _rightLimitForTree.y, -1);
        return pos;
    }
}
