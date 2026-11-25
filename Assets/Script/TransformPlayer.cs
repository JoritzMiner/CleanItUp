
using UnityEngine;
using System.Collections.Generic;

public class TransportarPlayer : MonoBehaviour
{
    public Transform player;

    private bool transportando;
    private Vector3 posicionAnterior;
    private HashSet<Collider> collidersPlayer = new HashSet<Collider>();

    void LateUpdate()
    {
        if (transportando && player != null)
        {
            Vector3 movimiento = transform.position - posicionAnterior;
            player.position += movimiento;
        }

        posicionAnterior = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player == null)
            return;

        if (other.transform == player || other.transform.IsChildOf(player))
        {
            collidersPlayer.Add(other);
            transportando = true;
            posicionAnterior = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!collidersPlayer.Contains(other))
            return;

        collidersPlayer.Remove(other);

        if (collidersPlayer.Count == 0)
        {
            transportando = false;

            float[] nivelesZ = { -3f, -2f, -1f, 1f, 2f, 3f };
            float zCercana = nivelesZ[0];

            foreach (float z in nivelesZ)
            {
                if (Mathf.Abs(player.position.z - z) <
                    Mathf.Abs(player.position.z - zCercana))
                {
                    zCercana = z;
                }
            }

            Vector3 posicion = player.position;
            posicion.z = zCercana;
            player.position = posicion;
        }
    }
}
