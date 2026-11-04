using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField]
    private SpawnFilaController spawnFilaController;

    [SerializeField]
    private GameObject camara;

    protected virtual void Awake()
    {
        spawnFilaController = FindFirstObjectByType<SpawnFilaController>();
        Spawnear();
        camara = GameObject.Find("Main Camera");
    }

    protected virtual void Update()
    {
        if(camara.transform.position.x > this.transform.position.x)
        {
            //Debug.LogError("016 Me voy " + this.gameObject.name);
            spawnFilaController.RemoveObject(gameObject);
        }
    }

    public virtual void Spawnear()
    {

    }
}
