using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    SpawnFilaController spawnFilaController;

    [Header("Prefab Tiles")]
    public GameObject inicioPrefab;
    public GameObject GrassPrefab;
    public GameObject WaterPrefab;
    public GameObject RoadPrefab;

    [Header("Camara")]
    public GameObject camara;

    private float UltimaPos = 0;
    private int tileDeAgua = 0;
    enum GameState
    {
        Menu,
        Playing,
        Death
    }
    GameState gameState;

    private void Awake()
    {
        spawnFilaController = FindFirstObjectByType<SpawnFilaController>();
        gameState = GameState.Playing;
        //spawnFilaController.ActivateObject(inicioPrefab, new Vector3(UltimaPos, 0, 0));
        //UltimaPos = 1.5f;
    }

    private void FixedUpdate()
    {
        if (gameState == GameState.Playing)
        {
            float posCamara = camara.transform.position.x + 24.0f;
            //Debug.LogError("007 " + UltimaPos + " -- " + posCamara);

            if (UltimaPos < posCamara)
            {
                Tile(RandomTile());
            }
        }

    }

    private int RandomTile()
    {
        int probabilidad = Random.Range(0, 100);
        int tile = 0;


        if ( probabilidad >= 0 && probabilidad <60 )
        {
            tile = 0;
        }else if(probabilidad >= 61 && probabilidad < 90)
        {
            tile = 1;
        }
        else if(tileDeAgua == 0)
        {
            tileDeAgua = 3;
            tile = 2;
        }

        if(tileDeAgua > 0)
        {
            tile = 2;
            tileDeAgua -= 1;

        }
            return tile;
    }
    private void Tile(int tipoTile)
    {
        if (tipoTile == 0)
        {
            //Debug.LogError("008 Tipo tile Grass");

            spawnFilaController.ActivateObject(GrassPrefab, new Vector3(UltimaPos, 0, 0));
        }
        else if (tipoTile == 1) 
        {
            //Debug.LogError("008 Tipo tile Road");

            spawnFilaController.ActivateObject(RoadPrefab, new Vector3(UltimaPos, 0, 0));
        }
        else
        {
            //Debug.LogError("008 Tipo tile Water");

            spawnFilaController.ActivateObject(WaterPrefab, new Vector3(UltimaPos, 0, 0));
        }
        UltimaPos = UltimaPos + 1.5f;
    }

}
