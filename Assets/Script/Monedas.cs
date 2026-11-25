using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public GameObject Player;
    public TMP_Text pointsTextMoneda;
    public float pointsMoneda = 0;
    public GameObject Player;
    //public float newPointsMoneda = 0;

    [SerializeField]
    private SpawnFilaController spawnFilaController;

    private void Start()
    {
        Player = FindFirstObjectByType<Controller>().gameObject;
        pointsTextMoneda.text = "Dinero: " + pointsMoneda.ToString();

    }

    private void Update()
    {
        if (Player.transform.position.x == this.transform.position.x)
        {
            //Debug.LogError("016 Me voy " + this.gameObject.name);
            spawnFilaController.RemoveObject(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) // Usa OnTriggerEnter si trabajas en 3D
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Moneda recogida!");
            
            pointsMoneda++;
            pointsTextMoneda.text = "Dinero: " + pointsMoneda.ToString();
        }
    }

}