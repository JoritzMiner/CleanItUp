using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private string NombreColision;
    public Controller Player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("TriggerMuro")) 
        {
            Debug.Log("ColisionaMuro" + NombreColision);
            ComprobarColision(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("TriggerMuro"))
        {
            Debug.Log("SaleColision" + NombreColision);
            ComprobarColision(true);
        }
    }
    private void ComprobarColision(bool libre)
    {
        if (NombreColision == "Arriba")
        {
            Player.MAdelante = libre;
        }
        if (NombreColision == "Abajo")
        {
            Player.MAtras = libre;
        }
        if (NombreColision == "Izquierda")
        {
            Player.MIzquierda = libre;
        }
        if (NombreColision == "Derecha")
        {
            Player.MDerecha = libre;
        }
    }
}
