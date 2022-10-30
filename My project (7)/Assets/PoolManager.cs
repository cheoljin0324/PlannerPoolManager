using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    GameObject containerPrefab;

    [SerializeField]
    PullProfile[] newProfile;

    private void Awake()
    {
        for (int i = 0; i < newProfile.Length; i++)
        {
            GameObject newContainer = Instantiate(containerPrefab);
            newContainer.name = newProfile[i].name;
            for (int j = 0; j < newProfile[i].defalutAmount; j++)
            {
                GameObject prefab = Instantiate(newProfile[i].prefabSet, newContainer.transform);
                prefab.transform.position = newProfile[i].defalutVector;
            }
        }



    }


    private void Init()
    {
        for (int i = 0; i < newProfile.Length; i++)
        {
            GameObject newContainer = Instantiate(containerPrefab);
            newContainer.name = newProfile[i].name;
            for (int j = 0; j < newProfile[i].defalutAmount; j++)
            {
                GameObject prefab = Instantiate(newProfile[i].prefabSet, newContainer.transform);
                prefab.transform.position = newProfile[i].defalutVector;
            }
        }
    }


}

[System.Serializable]
struct PullProfile
{
    [Header("������Ʈ �̸�")]
    public string name;
    [Header("�⺻ �� ����")]
    public int defalutAmount;
    [Header("�߰� �� ����")]
    public int AddAmount;
    [Header("���� ������Ʈ")]
    public GameObject prefabSet;
    [Header("�⺻ ��ġ ��ǥ")]
    public Vector3 defalutVector;
}
