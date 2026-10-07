using UnityEngine;

public class CrossyCamera : MonoBehaviour
{
    public Transform player;          // Arrastra aquí el objeto del jugador
    public Vector3 offset;            // Distancia fija entre la cámara y el jugador
    public float scrollSpeed = 2f;    // Velocidad a la que avanza la cámara automáticamente

    void Start()
    {
        if (player != null)
        {
            // Calcula la distancia inicial si no se asigna manualmente en el inspector
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Mueve la cámara hacia adelante constantemente en el eje Z (o el que prefieras)
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Opcional: Si quieres que también siga al jugador lateralmente (eje X)
        if (player != null)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.x = player.position.x + offset.x;

            // Mantiene el límite inferior para que la cámara no retroceda
            if (player.position.z + offset.z > transform.position.z)
            {
                targetPosition.z = player.position.z + offset.z;
            }

            transform.position = targetPosition;
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovCamara : MonoBehaviour
//{
//    public GameObject player; // drag player gameobject into this in inspector
//    public float cameraFollowSpeed; // how fast it should follow
//    public float offset; // how far u want the camera away
//    public bool isSmoothFollow = true; // lerp or not
//    public float speed = 2f;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.Translate(speed * Time.deltaTime, 0, 0);
//        if (player)
//        {
//            Vector3 newCameraPosition = transform.position;
//            newCameraPosition.x = player.transform.position.x;
//            newCameraPosition.z = player.transform.position.z - offset;
//            // you might need to change these

//            if (!isSmoothFollow)
//            {
//                transform.position = newCameraPosition;
//            }
//            else
//            {
//                transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraFollowSpeed * Time.deltaTime);
//            }
//        }
//    }
//}
