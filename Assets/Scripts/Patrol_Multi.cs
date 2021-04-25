using UnityEngine;

public class Patrol_Multi : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] targets;
    private Vector3[] targetsTemp;
    private bool rev = false;
    [SerializeField]
    private int index = 1;

    private void Start()
    {
        targetsTemp = new Vector3[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targetsTemp[i] = targets[i].position;
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetsTemp[index], speed * Time.deltaTime);

        if (transform.position == targetsTemp[index])
        {
            if (!rev)
                index++;
            else
                index--;

            if (index == targetsTemp.Length - 1 || index == 0)
                rev = !rev;

            Vector3 temp = targetsTemp[index] - transform.position;
            float rotZ = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

}
