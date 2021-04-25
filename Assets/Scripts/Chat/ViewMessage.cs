using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ViewMessage : MonoBehaviour//отображает диалог
{

    [SerializeField]
    GameObject oneMessage;//генерируемый объект(текст в чате)

    ScrollRect scrollRect;//scroll

    [SerializeField]
    GameObject content;//сообщение генерится здесь

    [SerializeField]
    GameObject spawnX;


    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    
    void Update()
    {
        
    }


    float y;
    public void AddMessage(string text,int direction)//отображает новое сообщение
    {
        if (direction == 1)
        {
            LeftMessage(text);

            content.transform.position += Vector3.up*2f;
        }

        if (direction == -1)
        {
            RightMessage(text);

            content.transform.position += Vector3.up*2f;
        }
    }

    void LeftMessage(string text)
    {
        oneMessage.GetComponent<Text>().text = text;

        GameObject message = Instantiate(oneMessage);

        message.transform.SetParent(content.transform);

        Transform child = message.transform.Find("Message");//внутренний текст

        child.GetComponent<Text>().text = text;

        RectTransform rect = content.GetComponent<RectTransform>();

        rect.sizeDelta = new Vector2(rect.rect.width, rect.rect.height + 300);

    }

    void RightMessage(string text) 
    {
        oneMessage.GetComponent<Text>().text = text;

        GameObject message = Instantiate(oneMessage);

        message.transform.SetParent(content.transform);

        Transform child = message.transform.Find("Message");

        child.GetComponent<Text>().text = text;

        RectTransform rect = content.GetComponent<RectTransform>();

        rect.sizeDelta = new Vector2(rect.rect.width, rect.rect.height + 300);

        message.GetComponent<RectTransform>().position = new Vector3(message.GetComponent<RectTransform>().position.x+250, message.GetComponent<RectTransform>().position.y);


        GameObject image = message.transform.Find("Image").gameObject;

        GameObject str = message.transform.Find("Message").gameObject;

        message.GetComponent<Text>().color = new Color(message.GetComponent<Text>().color.r, message.GetComponent<Text>().color.g, message.GetComponent<Text>().color.b, 0);



        image.GetComponent<RectTransform>().localPosition += Vector3.right * 300;
        str.GetComponent<RectTransform>().localPosition += Vector3.right * 300;

        rect.sizeDelta = new Vector2(rect.rect.width, rect.rect.height + 300);
    }


    public void AllMessage(Dialog dialog)//отображает то что было написано раньше
    {
        int indexNpc = 0;
        int indexPlayer = 0;
        RectTransform rect = content.GetComponent<RectTransform>();
        for (int i = 0; i < dialog.indexOrder; i++)
        {
            if (dialog.orders[i] == 0)
            {
                continue;
            }

            if (dialog.orders[i] == 1)
            {
                AddMessage(dialog.npcWords[indexNpc],1);
                indexNpc++;
                
            }

            if (dialog.orders[i] == 2)
            {
                int[] selectedAnswer = dialog.selectedAnswer;
                AddMessage(dialog.playerWords[indexPlayer].str[selectedAnswer[indexPlayer]],-1);//генерация выбранного варианта ответа
                indexPlayer++;
            }
        }
    }
}
