using UnityEngine;
using UnityEngine.InputSystem;

public class Destruir : MonoBehaviour
{
    [SerializeField] private Transform gaviota_Transform;
    public float scrollSpeed = 2f;    // Velocidad a la que avanza la cámara automáticamente
                                      // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 posicionInicial;
    [SerializeField]
    private GameObject Player = null;

    private float moveSpeed; // Velocidad a la que se mueve el objeto

    // Update is called once per frame
    private void Start()
    {
        gaviota_Transform = this.transform;
        if(this.name == "CapsuleMosca(Clone)")
        {
            moveSpeed = Random.Range(5, scrollSpeed);

        }
        else if (this.name == "CapsuleGaviota(Clone)")
        {
            moveSpeed = Random.Range(3, scrollSpeed);

        }
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PosicionInicial(Vector3 posiciontile)
    {
        posicionInicial = posiciontile;
        Debug.LogError("015 " + posicionInicial);

    }

    private void Update()
    {
        gaviota_Transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if(gaviota_Transform.position.z > 8f)
        {
            Debug.Log("015 " + posicionInicial);
            ResetPOs();
        }
        if(Player.transform.position.x == gaviota_Transform.position.x && Player.transform.position.z == gaviota_Transform.position.z)
        {
            GameManager.Instance.GameOver();
        }

    }
    public void ResetPOs()
    {
        this.transform.position = new Vector3(gaviota_Transform.position.x, gaviota_Transform.position.y, gaviota_Transform.position.z - 16);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}