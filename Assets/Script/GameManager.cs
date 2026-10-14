using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public SpawnFilaController TilePool;
    private float UltimaPos = 0;
    private int TilesEnPantalla = 0;

    private void Awake()
    {
        for(int i = 0; i < 17; i++)
        {
            CrearMapa();
            StartCoroutine(EsperarTiles());
        }
        Debug.Log("001 Tiles Creadas " + TilesEnPantalla);
        
    }

    private void FixedUpdate()
    {
        
    }

    void CrearMapa()
    {
        GameObject tile = TilePool.GetObject();
        tile.transform.position = new Vector3(UltimaPos,0,0);
        UltimaPos = (float)(UltimaPos + 1.5);
        TilesEnPantalla++;
        Debug.Log("003 Nueva Tile " + TilesEnPantalla);

        StartCoroutine(DesactivateMapa(tile));
    }

    IEnumerator DesactivateMapa(GameObject Tile)
    {
        yield return new WaitForSeconds(18f);
        TilePool.ReturnObject(Tile);
    }

    IEnumerator GenerarTiles()
    {
        yield return new WaitForSeconds(5f);
        if(TilesEnPantalla < 30)
        {
            Debug.Log("004 Not enought tiles" + TilePool.pool.Count);

            CrearMapa();

        }
    }

    IEnumerator EsperarTiles()
    {
        yield return new WaitForSeconds(2f);
    }
}
