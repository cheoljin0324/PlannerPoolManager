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
    [Header("오브젝트 이름")]
    public string name;
    [Header("기본 값 갯수")]
    public int defalutAmount;
    [Header("추가 값 갯수")]
    public int AddAmount;
    [Header("게임 오브젝트")]
    public GameObject prefabSet;
    [Header("기본 위치 좌표")]
    public Vector3 defalutVector;
}
