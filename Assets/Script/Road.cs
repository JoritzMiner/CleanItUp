using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    private SpawnFilaController spawnFilaController;

    [SerializeField]
    private GameObject camara;

    private void Awake()
    {
        spawnFilaController = FindFirstObjectByType<SpawnFilaController>();
        camara = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if(camara.transform.position.x > this.transform.position.x)
        {
            spawnFilaController.RemoveObject(gameObject);
        }
    }
}
