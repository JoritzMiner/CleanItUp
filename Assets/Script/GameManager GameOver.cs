using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerGAMEOVER : MonoBehaviour
{
    public static GameManagerGAMEOVER Instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    public Button reiniciarButton;
    public Button menuButton;

    public int valorAleatorio;

    private bool gameOverActivo = false;

    private void Awake()
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

    void Start()
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

    void Update()
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
    }

    public void TextoAleatorio()
    {
        valorAleatorio = Random.Range(1, 10);

        if (valorAleatorio == 1)
        {
            gameOverText.text = "Te queria ver triunfar pero no me daras el gusto";
        }

        if (valorAleatorio == 2)
        {
            gameOverText.text = "Amar tambien es dejar ir";
        }
        if (valorAleatorio == 3)
        {
            gameOverText.text = "Iluminas cada lugar del que sales";
        }
        if (valorAleatorio == 4)
        {
            gameOverText.text = "¡Estas cerrando bocas, sigue asi!";
        }
        if (valorAleatorio == 5)
        {
            gameOverText.text = "¡Me pongo el sombrero!";
        }
        if (valorAleatorio == 6)
        {
            gameOverText.text = "Sigue asi y llegaras muy cerca";
        }
        if (valorAleatorio == 7)
        {
            gameOverText.text = "Eres un jugador de los pies a los tobillos";
        }
        if (valorAleatorio == 8)
        {
            gameOverText.text = "Y pintar no te gusta?";
        }
        if (valorAleatorio == 9)
        {
            gameOverText.text = "¡Tienes talento, solo falta buscarlo!";
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


public class NewMonoBehaviourScript : MonoBehaviour
    {

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


        }
    }
}
