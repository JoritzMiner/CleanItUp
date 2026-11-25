using UnityEngine;

[System.Serializable]
public class ZonaX
{
    public float xMin;
    public float xMax;
    public float[] nivelesZ = { -3f, -2f, -1f, 1f, 2f, 3f };
}

public class Gondola : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Rigidbody playerRb;
    public Collider zonaContacto;
    public float velocidad = 1f;
    public int pasosDeAjuste = 10;

    public ZonaX[] zonas;
    public float[] nivelesPorDefecto = { -3f, -2f, -1f, 1f, 2f, 3f };

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 target;
    private Collider playerCol;

    private bool transportando;
    private int pasosRestantes;
    private float zObjetivo;

    void Start()
    {
        posA = pointA.position;
        posB = pointB.position;
        target = posB;

        playerCol = playerRb.GetComponent<Collider>();

        if (zonaContacto == null)
            zonaContacto = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        Vector3 posicionAnterior = transform.position;

        transform.position = Vector3.MoveTowards(
            posicionAnterior,
            target,
            velocidad * Time.fixedDeltaTime
        );

        Physics.SyncTransforms();

        Vector3 movimiento = transform.position - posicionAnterior;

        if (Vector3.Distance(transform.position, target) < 0.001f)
            target = (target == posB) ? posA : posB;

        bool dentro = zonaContacto.bounds.Intersects(playerCol.bounds);

        if (dentro)
        {
            transportando = true;
            pasosRestantes = 0;
            playerRb.position += movimiento;
        }
        else if (transportando)
        {
            transportando = false;
            zObjetivo = CalcularZObjetivo(playerRb.position);
            pasosRestantes = pasosDeAjuste;
        }

        if (pasosRestantes > 0)
        {
            FijarZ();
            pasosRestantes--;
        }
    }

    private float[] ObtenerNiveles(float x)
    {
        foreach (ZonaX zona in zonas)
        {
            if (x >= zona.xMin && x <= zona.xMax && zona.nivelesZ != null && zona.nivelesZ.Length > 0)
                return zona.nivelesZ;
        }
        return nivelesPorDefecto;
    }

    private float CalcularZObjetivo(Vector3 pos)
    {
        float[] niveles = ObtenerNiveles(pos.x);

        float zCercana = niveles[0];
        foreach (float z in niveles)
        {
            if (Mathf.Abs(pos.z - z) < Mathf.Abs(pos.z - zCercana))
                zCercana = z;
        }
        return zCercana;
    }

    private void FijarZ()
    {
        Vector3 pos = playerRb.position;
        pos.z = zObjetivo;
        playerRb.position = pos;
        playerRb.transform.position = pos;

        Vector3 vel = playerRb.linearVelocity;
        vel.z = 0f;
        playerRb.linearVelocity = vel;

        if (pasosRestantes == 1)
            Debug.Log("Z final: " + playerRb.position.z + " | X final: " + playerRb.position.x);
    }
}