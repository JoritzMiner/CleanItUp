
using UnityEngine;
using System.Collections.Generic;

public class Gondola : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Rigidbody playerRb;
    public float velocidad = 1f;

    private Vector3 target;
    private Vector3 posicionAnterior;
    private bool transportando;

    private HashSet<Collider> contactos = new HashSet<Collider>();

    void Start()
    {
        target = pointB.position;
        posicionAnterior = transform.position;
    }

    void Update()
    {
        Vector3 posicionActual = transform.position;

        transform.position = Vector3.MoveTowards(
            posicionActual,
            target,
            velocidad * Time.deltaTime
        );

        Vector3 movimiento = transform.position - posicionActual;

        if (transportando && playerRb != null)
        {
            playerRb.position += movimiento;
        }

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            target = target == pointB.position ? pointA.position : pointB.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerRb == null)
            return;

        if (other.attachedRigidbody == playerRb)
        {
            contactos.Add(other);
            transportando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!contactos.Contains(other))
            return;

        contactos.Remove(other);

        if (contactos.Count == 0)
        {
            transportando = false;

            float[] nivelesZ = { -3f, -2f, -1f, 1f, 2f, 3f };
            float zCercana = nivelesZ[0];

            foreach (float z in nivelesZ)
            {
                if (Mathf.Abs(playerRb.position.z - z) <
                    Mathf.Abs(playerRb.position.z - zCercana))
                {
                    zCercana = z;
                }
            }

            Vector3 posicion = playerRb.position;
            posicion.z = zCercana;
            playerRb.position = posicion;
        }
    }
}
