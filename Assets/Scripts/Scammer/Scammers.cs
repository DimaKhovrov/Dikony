using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scammers : MonoBehaviour//ChatMenu
{
    [SerializeField]
    GameObject content;//������� ���� ����

    [SerializeField]
    GameObject prefab;//��������� ����

    void Start()
    {
        StartCoroutine(startScamin());
    }


    public void Generate()
    {
       GameObject chat= Instantiate(prefab);

        chat.transform.SetParent(content.transform);
    }

    public IEnumerator startScamin()
    {
        yield return new WaitForSeconds(60);

        Generate();
    
    }
}
