using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    [SerializeField]
    GameObject content;

    ChatAnim chat;

    [SerializeField]
    Transform center;

    float speed=10;


    [SerializeField]
    GameObject []windows;

    void Start()
    {
        chat = GameObject.FindGameObjectWithTag("ChatScroll").GetComponent<ChatAnim>();
    }

    
    void Update()
    {
        
    }


    public void Close()
    {
        RectTransform[] childs = content.GetComponentsInChildren<RectTransform>();

        for (int i = 1; i < childs.Length; i++)
        {
//            if (child)
            Destroy(childs[i].gameObject);
        }

        StartCoroutine(chat.Animation(-1));
        
        RectTransform rect = content.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width,0);
    }


    public void ChatButt()
    {
        //StartCoroutine(Animation(1,windows[0]));
    }

    public void DronButt(int direction)
    {
        StartCoroutine(Animation(direction, windows[1]));
    }


    public void StoreButt(int direction)
    {
        StartCoroutine(Animation(direction, windows[2]));
    }

    public IEnumerator Animation(int direction,GameObject window) //1 если появляется иначе -1
    {
        if (direction == 1)
            while (window.GetComponent<RectTransform>().offsetMin.x >= 0.0)
            {
                window.transform.position = new Vector2(window.transform.position.x - speed * Time.deltaTime, window.transform.position.y);
                yield return null;
            }
        else
        {
            while (window.GetComponent<RectTransform>().offsetMax.x - center.GetComponent<RectTransform>().offsetMax.x < 0)
            {
                window.transform.position = new Vector2(window.transform.position.x + speed * Time.deltaTime, window.transform.position.y);
                yield return null;
            }
        }
    }

}
