using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenAnswers : MonoBehaviour
{
    public event EventHandler AnswerIsClicked;//вызывается если я кликнул ответ

    public int indexClicked = -1;//какой ответ дан (индекс)

    Button butt;

    [SerializeField]
    GameObject prefab, content;//префаб баттона

    Dialog currentDialog;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate(string[] words, Dialog dialog)//генерирует варианты ответа
    {
        currentDialog = dialog;
        for (int i = 0; i < words.Length; i++)
        {
            GameObject answer = Instantiate(prefab);
            answer.GetComponent<Text>().text = words[i];

            //установка обработки
            Button butt = answer.transform.Find("Button").GetComponent<Button>();
            int x = new int();
            x = i;
            butt.onClick.AddListener(delegate { ClickAnswer(x); });

            GameObject child = butt.transform.Find("Answer").gameObject;
            child.GetComponent<Text>().text = words[i];

            answer.transform.SetParent(content.transform);

            //увеличение размера контента
            RectTransform rect = content.GetComponent<RectTransform>();

            rect.sizeDelta = new Vector2(rect.rect.width + 300, rect.rect.height);

        }
    }


    public void ClickAnswer(int index)//обрабатывает нажатие ответа
    {
        indexClicked = index;
        //AnswerIsClicked?.Invoke(this, EventArgs.Empty);
        currentDialog.Answers_AnswerIsClicked(this);
        //print(index);
        Clear();
    }

    IEnumerator DeleteData()
    {
        yield return new WaitForSeconds(1f);

        indexClicked = -1;
    }


    void Clear()//очищает выбор ответа
    {
        RectTransform[] childs = content.GetComponentsInChildren<RectTransform>();

        for (int i = 1; i < childs.Length; i++)
        {
            Destroy(childs[i].gameObject);
        }

        RectTransform rect = content.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width, 0);
    }
}
