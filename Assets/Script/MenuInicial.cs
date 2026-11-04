using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject PanelInicial;

    public Button Jugarbtt;
    public Button Opcionesbtt;
    public Button Salirbtt;


    public void JugarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
