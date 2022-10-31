using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    GameObject containerPrefab;

    [SerializeField]
    PullProfile[] new1Profile;

    static PullProfile[] newProfile;

    private void Awake()
    {
        newProfile = new PullProfile[new1Profile.Length];

        for(int i = 0; i<new1Profile.Length; i++)
        {
            newProfile[i] = new1Profile[i];
        }
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
                prefab.SetActive(false);
                newProfile[i].inConObject.Enqueue(prefab);
            }
        }
    }

    public static void AddAmount(Queue<GameObject> set, GameObject addObject)
    {
        set.Enqueue(Instantiate(addObject));
    }

    public static GameObject PoolRequest(Queue<GameObject> set,GameObject pullObject, Vector3 pos, Quaternion rot)
    {
        if(set.Count == 0)
        {
            AddAmount(set, pullObject);
        }
        set.Peek().SetActive(true);
        set.Peek().transform.position = pos;
        set.Peek().transform.rotation = rot;

        GameObject nowpeek = set.Peek();
        set.Dequeue();
        return nowpeek;
    }



    public static GameObject PoolRequest(string objName)
    {
        for(int i = 0; i<newProfile.Length; i++)
        {
            if(newProfile[i].name == objName)
            {
                return PoolRequest(newProfile[i].inConObject,newProfile[i].inConObject.Peek(), new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
            }
        }

        return null; 
    }

    public static GameObject PoolRequest(string objName, Vector3 pos)
    {
        for (int i = 0; i < newProfile.Length; i++)
        {
            if (newProfile[i].name == objName)
            {
                return PoolRequest(newProfile[i].inConObject,newProfile[i].inConObject.Peek(), pos, new Quaternion(0, 0, 0, 0));
            }
        }
        return null; 
    }

    public static GameObject PoolRequest(string objName, Vector3 pos, Quaternion rot)
    {
        for (int i = 0; i < newProfile.Length; i++)
        {
            if (newProfile[i].name == objName)
            {
                return PoolRequest(newProfile[i].inConObject,newProfile[i].inConObject.Peek(), pos, rot);
            }
        }
        return null; 
    }

    public static void CullObject(GameObject cullObject)
    {
        cullObject.SetActive(false);
        cullObject.transform.position = new Vector3(0, 0, 0);
        cullObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < newProfile.Length; i++)
        {
            if (cullObject.transform.parent == newProfile[i].container)
            {
                newProfile[i].inConObject.Enqueue(cullObject);
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
