using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFilaController : MonoBehaviour
{
    private Dictionary<GameObject,Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

    public GameObject InicioPrefab;

    public GameObject GrassPrefab;
    public GameObject WaterPrefab;
    public GameObject RoadPrefab;


    private void Start()
    {
        CreatePool(InicioPrefab, 1);
        CreatePool(GrassPrefab, 14);
        CreatePool(WaterPrefab, 6);
        CreatePool(RoadPrefab, 8);
    }
    private void CreatePool(GameObject prefab, int poolSize)
    {
        Queue<GameObject> newPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.GetComponent<PrefabIdentifier>().SetPrefab(prefab);
            obj.SetActive(false);
            newPool.Enqueue(obj);
        }
        pools[prefab] = newPool;
    }

    public void ActivateObject(GameObject prefab, Vector3 position)
    {
        Queue<GameObject> pool = pools[prefab];
        //Debug.Log("009"+pool.Count);

        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.position = position;
        }
    }

    public void RemoveObject(GameObject obj)
    {
        //Debug.LogError("010");

        obj.SetActive(false);
        pools[obj.GetComponent<PrefabIdentifier>().prefab].Enqueue(obj);
    }
}
