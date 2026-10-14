using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFilaController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FilasPosibles = new GameObject[3];

    public Queue<GameObject> pool = new Queue<GameObject>();

    private int ran;

    public GameObject GetObject()
    {
        if(pool.Count > 0 && pool.Count < 17)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(RandomizarTiles());
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    private GameObject RandomizarTiles()
    {
        ran = Random.Range(0, 3);
        return FilasPosibles[ran];
    }
}
