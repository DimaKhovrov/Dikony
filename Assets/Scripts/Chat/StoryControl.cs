using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryControl : MonoBehaviour
{
    [SerializeField]
    GameObject[] chats;

    Text[] text;

    int[] orderEvents;//порядок событий

    int currentIndex;//последнее событие которое наступило

    void Start()
    {

        text = new Text[chats.Length];

        for (int i = 0; i < chats.Length; i++)
        {
            text[i] = chats[i].transform.Find("MessageCame").GetComponent<Text>();
        }

        text[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ComeEvent(int index)
    {
        
    }
}
