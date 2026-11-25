using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrassTile : Tiles
{
    public GameObject ParedPrefab;
    public GameObject Moneda;

    private Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();


    public int valorAleatorio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        CreatePool(ParedPrefab, 4);
        CreatePool(Moneda, 1);

        base.Awake();
    }

    protected override void Update()
    {
       base.Update();
    }

    private void CreatePool(GameObject prefab, int poolSize)
    {
        //Debug.Log("018 Create pool");
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

    public override void Spawnear()
    {
        valorAleatorio = Random.Range(0, 3);
        int posicionAleatoria;
        int[] posBloques = new int[3];
        for (int i = 0; i <= valorAleatorio; i ++)
        {
            posicionAleatoria = Random.Range(0, 7);
            posBloques[i] = posicionAleatoria;
            //Debug.LogError("020 Me spawneo " + ParedPrefab.name + " en la posicion " + posicionAleatoria);
            ActivateObject(ParedPrefab, new Vector3(0, 1, posicionAleatoria - 1.1417f));
        }
        bool monedaSpawn = true;
        int contador = 0;
        while (monedaSpawn)
        {
            contador = 0;
            posicionAleatoria = Random.Range(0, 7);
            for(int i = 0;i <= valorAleatorio; i ++)
            {
                if(posicionAleatoria == posBloques[i])
                {
                    contador++;
                }
            }

            if(contador == 0)
            {
                ActivateObject(Moneda, new Vector3(0, 1, posicionAleatoria - 1.1417f));
                monedaSpawn=false;
            }
        }
    }

}
