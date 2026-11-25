using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject objeto;

    private bool transportando;

    private void OnTriggerEnter(Collider other)
    {
        if (objeto != null &&
            (other.gameObject == objeto ||
             other.transform.IsChildOf(objeto.transform)))
        {
            objeto.transform.SetParent(transform, true);
            transportando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!transportando || objeto == null)
            return;

        if (other.gameObject == objeto ||
            other.transform.IsChildOf(objeto.transform))
        {
            Vector3 posicion = objeto.transform.position;

            objeto.transform.SetParent(null, true);
            transportando = false;

            float[] nivelesZ = { -3f, -2f, -1f, 1f, 2f, 3f };
            float zCercana = nivelesZ[0];

            foreach (float nivel in nivelesZ)
            {
                if (Mathf.Abs(posicion.z - nivel) <
                    Mathf.Abs(posicion.z - zCercana))
                {
                    zCercana = nivel;
                }
            }

            posicion.z = zCercana;
            objeto.transform.position = posicion;
        }
    }
}