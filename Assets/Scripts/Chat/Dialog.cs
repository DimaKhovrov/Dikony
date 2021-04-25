using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    
    public string[] npcWords;//слова персонажа
    
    
    public Array[] playerWords;//слова игрока с его выбором

    public int []selectedAnswer;//index выбранного ответа
    
    public int[] orders;//порядок диалогов и выбора ответа 0-остановка  1-npc слова 2-выбор

    public int indexNpc=0; //до index уже были произношены

    public int indexOrder=0;

    public int indexPlayer=0; //до index уже были произношены

    [SerializeField]
    float dTime;//время печатания npc

    float time;

    GenAnswers answers;

    public event EventHandler ComeHandler;//наступило какое-то событие

    ViewMessage view;//отображает диалоги 

    [SerializeField]
    AllEvents [] allEvents;

    public int indicator = 0;
    void Start()
    {
        time = dTime;

        view = GameObject.FindGameObjectWithTag("ChatScroll").GetComponent<ViewMessage>();

        if (playerWords!=null)
            selectedAnswer = new int[playerWords.Length];

        for (int i = 0; i < selectedAnswer.Length; i++)
            selectedAnswer[i] = -1;

        answers = GameObject.FindGameObjectWithTag("AnswerScroll").GetComponent<GenAnswers>();

       // answers.AnswerIsClicked += Answers_AnswerIsClicked;

        //StartEvents();
    }


    private void OnDisable()
    {
        //
    }

    public void Answers_AnswerIsClicked(object sender)//работает когда получил ответ
    {
        GenAnswers gen = sender as GenAnswers;
        
        int index = gen.indexClicked;

        view.AddMessage(playerWords[indexPlayer-1].str[index],-1);//вывод ответа

        selectedAnswer[indexPlayer - 1] = index;

        //indexOrder++;

       StartCoroutine(StartEvents());//продолжает работу если дан ответ
        
    }

    void Update()
    {

    }

    public void AllMessage()//отображает всех ранних переписок
    {
        view.AllMessage(this);

        if (allEvents[indicator].isCome==false)
        {
            StartCoroutine(StartEvents());
        }
    }


    public IEnumerator StartEvents()//печатывает сообщения
    {

       // if (allEvents[indicator].isCome == false)
       // {
            allEvents[indicator].isCome = true;
            for (int i = indexOrder; i < orders.Length; i++)
            {
                if (orders[i] == 0)
                {
                    indexOrder = i+1;
                    break;
                }

                if (orders[i] == 1)
                {
                    yield return new WaitForSeconds(dTime);
                    view.AddMessage(npcWords[indexNpc], 1);
                    indexNpc++;
                    continue;
                }

                if (orders[i] == 2)
                {
                    if (indexPlayer < playerWords.Length)
                        answers.Generate(playerWords[indexPlayer].str, this);//генерация вариантов ответа
                    indexPlayer++;
                    indexOrder = i+1;
                    break;
                }
            }
        //}
    }

    [Serializable]
    public class Array
    {
        public string []str;
    
    }

    [Serializable]
    public class AllEvents
    {
        public int l, r;
        public bool isCome=false;
    }
}


