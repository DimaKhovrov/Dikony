using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public float Price, AddEn;

    [SerializeField]
    public GameObject textEnergy, textPrice;
    

    public void Buy()
    {
        //......
        textPrice.GetComponent<Text>().text = Price.ToString();
        textEnergy.GetComponent<Text>().text = AddEn.ToString();
        Debug.Log("Цена: " + Price + " и добавил " + AddEn + " энергии");
    }
}
