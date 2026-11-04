using UnityEngine;

public class Gondola : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform plataforma;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;   
    }

    void Update()
    {
        plataforma.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
        
        if(transform.position == target)
        {
            target = target == pointB.position ? pointA.position : pointB.position;
        }
    }
}
