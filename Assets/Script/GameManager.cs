using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    SpawnFilaController spawnFilaController;

    public static GameManager Instance;

    [Header("Prefab Tiles")]
    public GameObject inicioPrefab;
    public GameObject GrassPrefab;
    public GameObject WaterPrefab;
    public GameObject RoadPrefab;

    [Header("Camara")]
    public GameObject camara;
    public GameObject Player;

    private float UltimaPos = 0;
    private int tileDeAgua = 0;
    private int SacarAgua = 0;

    enum GameState
    {
        Menu,
        Playing,
        Death
    }
    GameState gameState;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    public Button reiniciarButton;
    public Button menuButton;

    public int valorAleatorio;

    private bool gameOverActivo = false;

    private void Awake()
    {
        CreateInstane();//para Game Over
        

        spawnFilaController = FindFirstObjectByType<SpawnFilaController>();
        gameState = GameState.Playing;
        //spawnFilaController.ActivateObject(inicioPrefab, new Vector3(UltimaPos, 0, 0));
        //UltimaPos = 1.5f;
    }

    private void Start()
    {
        PanelMuerte();

    }

    private void CreateInstane()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void PanelMuerte()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (reiniciarButton != null)
        {
            reiniciarButton.onClick.AddListener(ReiniciarEscena);
        }
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(IrAlMenu);
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        gameState = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        gameState = GameState.Menu;
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
        if (gameState == GameState.Death)
        {
            if (gameOverActivo)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {

                    ReiniciarEscena();
                }

                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.M))
                {
                    IrAlMenu();
                }

            }
        }
        if (Player.transform.position.x <= camara.transform.position.x || Player.transform.position.x > camara.transform.position.x + 17)
        {
            GameOver();
        }
    }



    public void GameOver()
    {
        if (gameOverActivo) return;

        gameOverActivo = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null)
        {
            TextoAleatorio();
        }

        Debug.LogError("017 Me he matado paco");
        gameState = GameState.Death;

        camara.GetComponent<CrossyCamera>().scrollSpeed = 0;
    }

    public bool CheckIfDeath()
    {
        if (gameState == GameState.Death)
            return true;
        else
        {
            return false;
        }
    }

    private int RandomTile()
    {
        int probabilidad = Random.Range(0, 100);
        int tile = 0;


        if ( probabilidad >= 0 && probabilidad <60 )
        {
            if(SacarAgua < 14)
            {
                SacarAgua += 1;
            }
            tile = 0;
        }else if(probabilidad >= 61 && probabilidad < 90)
        {
            //Tile Carretera

            tile = 1;
        }
        else if(tileDeAgua == 0 && SacarAgua == 0)
        {
            tileDeAgua = 3;
            SacarAgua = 14;
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

    public void TextoAleatorio()
    {
        valorAleatorio = Random.Range(1, 10);

        if (valorAleatorio == 1)
        {
            gameOverText.text = "Te queria ver triunfar pero no me daras el gusto🗣️🗣️🔥🔥";
        }

        if (valorAleatorio == 2)
        {
            gameOverText.text = "Amar tambien es dejar ir🗣️🗣️🔥";
        }
        if (valorAleatorio == 3)
        {
            gameOverText.text = "Iluminas cada lugar del que sales🏮";
        }
        if (valorAleatorio == 4)
        {
            gameOverText.text = "Estas cerrando bocas, sigue asi👏👏👏";
        }
        if (valorAleatorio == 5)
        {
            gameOverText.text = "Me pongo el sombrero😲😲";
        }
        if (valorAleatorio == 6)
        {
            gameOverText.text = "Sigue asi y llegaras muy cerca🗣️🔥🔥";
        }
        if (valorAleatorio == 7)
        {
            gameOverText.text = "Eres un jugador de los pies a los tobillos🔥🔥";
        }
        if (valorAleatorio == 8)
        {
            gameOverText.text = "Pintar no te gusta?🗣️🗣️🗣️🗣️";
        }
        if (valorAleatorio == 9)
        {
            gameOverText.text = "Tienes talento, solo falta buscarlo😲😲🔥🔥";
        }
    }
}
