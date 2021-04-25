using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    StoryControl story;

    ChatAnim chatAnim;
    void Start()
    {
        story = GetComponent<StoryControl>();

        chatAnim = GameObject.FindGameObjectWithTag("ChatScroll").GetComponent<ChatAnim>();
    }

    LayerMask mask=1<<8;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,mask);

            Dialog dialog=null;

            if (hit.collider != null)
            {
                dialog = hit.collider.GetComponent<Dialog>();
            }
            else
                return;

            if (dialog!=null)
            {
                print(dialog.name);
                dialog.AllMessage();
                
                Hide(dialog);
                Open();
            }
        }
    }

    void Open()//открывает чат
    {
        StartCoroutine(chatAnim.Animation(1));
    }

    void Hide(Dialog dialog)
    {
        GameObject image = dialog.gameObject.transform.Find("MessageCame").gameObject;

        image.SetActive(false);
    }

}
