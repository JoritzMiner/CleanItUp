using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public GameObject Player;
    public TMP_Text pointsTextMoneda;
    public float pointsMoneda = 0;
    public GameObject Player;
    //public float newPointsMoneda = 0;

    private void Start()
    {
        //Player = FindFirstObjectByType<Controller>().gameObject;
        pointsTextMoneda.text = "Dinero: " + pointsMoneda.ToString();

    }

    private void Update()
    {

    }

    public void OnTriggerEnter(Collider other) // Usa OnTriggerEnter si trabajas en 3D
    {
        if (other.gameObject.CompareTag("Monedas"))
        {
            Debug.Log("¡Moneda recogida!");
            Destroy(other.gameObject); // Destruye la moneda de la escena
            pointsMoneda++;
            pointsTextMoneda.text = "Dinero: " + pointsMoneda.ToString();
        }
    }

}