using UnityEngine;

public class Maceta : MonoBehaviour
{
    [SerializeField] private Transform maceta_Transform;
    public float scrollSpeed = 2f;    // Velocidad a la que avanza la cámara automáticamente
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maceta_Transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        maceta_Transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player dañado Fin de partida");
        }

        if(other.gameObject.tag == "Pared")
        {
            this.gameObject.SetActive(false);
        }
    }
}
