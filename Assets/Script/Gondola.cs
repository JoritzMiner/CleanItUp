
using UnityEngine;

public class Gondola : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform plataforma;

    public float velocidad = 1f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        // Mover la plataforma hacia el destino
        plataforma.position = Vector3.MoveTowards(
            plataforma.position,
            target,
            velocidad * Time.deltaTime
        );

        // Comprobar si ha llegado al destino
        if (Vector3.Distance(plataforma.position, target) < 0.001f)
        {
            // Cambiar el destino
            target = target == pointB.position
                ? pointA.position
                : pointB.position;
        }
    }
}
