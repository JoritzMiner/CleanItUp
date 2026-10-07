using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    [SerializeField] private Transform gaviota_Transform;
    public float scrollSpeed = 2f;    // Velocidad a la que avanza la cámara automáticamente
                                      // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 posicionInicial;
  

    // Update is called once per frame
    private void Start()
    {
        posicionInicial = transform.position;
        gaviota_Transform = this.transform;
    }
    private void Update()
    {
        gaviota_Transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pared")
        {
            transform.position = posicionInicial;
           
        }
    }
}