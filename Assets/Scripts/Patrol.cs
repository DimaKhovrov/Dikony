using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform target;
    private Vector3 oldPosition, targetTemp;

    private void Start()
    {
        oldPosition = transform.position;
        targetTemp = target.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTemp, speed * Time.deltaTime);
        if (transform.position == targetTemp)
        {
            targetTemp = oldPosition;
            oldPosition = transform.position;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
