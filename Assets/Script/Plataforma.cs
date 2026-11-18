
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject objeto;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == objeto)
        {
            
            objeto.transform.SetParent(transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objeto)
        {
            
            objeto.transform.SetParent(null, true);

            
            Vector3 posicion = objeto.transform.position;

            
            float[] posicionesZ = { -3f, -2f, -1f, 1f, 2f, 3f };

            
            float zCercana = posicionesZ[0];

            foreach (float z in posicionesZ)
            {
                if (Mathf.Abs(posicion.z - z) <
                    Mathf.Abs(posicion.z - zCercana))
                {
                    zCercana = z;
                }
            }

            
            posicion.z = zCercana;

            objeto.transform.position = posicion;
        }
    }
}
