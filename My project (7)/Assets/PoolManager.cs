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
        Init();
    }


    public void Init()
    {
        for (int i = 0; i < newProfile.Length; i++)
        {
            GameObject newContainer = Instantiate(containerPrefab);
            newContainer.name = newProfile[i].name;
            newProfile[i].container = newContainer;
            for (int j = 0; j < newProfile[i].defalutAmount; j++)
            {
                GameObject prefab = Instantiate(newProfile[i].prefabSet, newContainer.transform);
                prefab.transform.position = newProfile[i].defalutVector;
                prefab.transform.parent = newContainer.transform;
                newProfile[i].inConObject.Enqueue(prefab);
            }
        }
    }

    public static void PullRequest(GameObject pullObject, Vector3 pos, Vector3 rotation)
    {

    }

    public static void PullRequest(string objName)
    {
        for(int i = 0; i<newProfile.Length; i++)
        {
            if(newProfile[i].name == objName)
            {
                
            }
        }
    }


}

[System.Serializable]
struct PullProfile
{
    [Header("�����̳� �̸�")]
    public string name;
    [Header("�⺻ �� ����")]
    public int defalutAmount;
    [Header("�߰� �� ����")]
    public int AddAmount;
    [Header("���� ������Ʈ")]
    public GameObject prefabSet;
    [Header("�����̳�")]
    [HideInInspector]
    public GameObject container;
    [Header("�⺻ ��ġ ��ǥ")]
    public Vector3 defalutVector;
    [Header("�����̳� ���� ������Ʈ")]
    public Queue<GameObject> inConObject;
}
