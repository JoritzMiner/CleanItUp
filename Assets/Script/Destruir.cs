using UnityEngine;
using UnityEngine.InputSystem;

public class Destruir : MonoBehaviour
{
    [SerializeField] private Transform gaviota_Transform;
    public float scrollSpeed = 2f;    // Velocidad a la que avanza la cámara automáticamente
                                      // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 posicionInicial;
  

    // Update is called once per frame
    private void Start()
    {
        gaviota_Transform = this.transform;
    }

    public void PosicionInicial(Vector3 posiciontile)
    {
        posicionInicial = posiciontile;
    }

    private void Update()
    {
        gaviota_Transform.position += Vector3.forward * scrollSpeed * Time.deltaTime;
        
    }
    public void ResetPOs()
    {
        this.transform.position = posicionInicial;
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pared")
        {
            Debug.Log("015 Me choque");
            scrollSpeed = 0f;
            this.gameObject.SetActive(false);
        }

        else if(other.gameObject.tag == "Player")
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}