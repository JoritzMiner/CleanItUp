using System.Collections.Generic;
using UnityEngine;

public class RoadTile : Tiles
{
    public GameObject PalomaPrefab;
    public GameObject MoscaPrefab;

    private GameObject PrefabDeFila;


    public int valorAleatorio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
       base.Update();
    }

    public override void Spawnear()
    {
        valorAleatorio = Random.Range(0, 2);

        Debug.Log("014 " + valorAleatorio);

        if (valorAleatorio == 0)
        {
            PrefabDeFila = PalomaPrefab;
        }
        else
        {
            PrefabDeFila = MoscaPrefab;
        }
        GameObject obj = Instantiate(PrefabDeFila, transform);
        obj.GetComponent<Destruir>().PosicionInicial(new Vector3(0,1, -9));
        Debug.Log("014 Deberia de spawnear");
    }

}
