using UnityEngine;

public class Product : MonoBehaviour
{
    public float Price, AddEn;

    public void Buy()
    {
        //......
        Debug.Log("Цена: " + Price + " и добавил " + AddEn + " энергии");
    }
}
