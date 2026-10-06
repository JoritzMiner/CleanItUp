using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private Vector2 TargetPosition;
    private float zInput, xInput;
    void Update()
    {
        zInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (zInput != 0 || xInput != 0)
        {
            CalculateTargetPosition();
        }
    }
    private void CalculateTargetPosition()
    {
        if(zInput == 1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if(zInput == -1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.left;
        }
        else if (xInput == 1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if(xInput == -1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.down;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(TargetPosition, 0.15f);
    }

}
