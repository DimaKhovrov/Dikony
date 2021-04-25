using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatAnim : MonoBehaviour//chat scroll
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform center;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public IEnumerator Animation(int direction) //1 если появляется иначе -1
    {
        if (direction == 1)
            while (this.GetComponent<RectTransform>().offsetMin.x >= 0.0)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                yield return null;
            }
        else
        {
            while (this.GetComponent<RectTransform>().offsetMax.x - center.GetComponent<RectTransform>().offsetMax.x < 0)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                yield return null;
            }
        }
    }
}
