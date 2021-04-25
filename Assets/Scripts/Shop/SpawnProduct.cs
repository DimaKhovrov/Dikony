using UnityEngine;
using UnityEngine.UI;

public class SpawnProduct : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private string[] names;
    [SerializeField]
    private Vector2[] priceAddEn;
    [SerializeField]
    private GameObject prefabs;

    private void Start()
    {
        for (int i = 0; i < names.Length; i++)
        {
            GameObject temp;
            temp = Instantiate(prefabs, transform);

            //temp.GetComponent<Image>();
            temp.GetComponentInChildren<Text>().text = names[i];

            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, rectTransform.rect.height + 100);

            temp.GetComponent<Product>().Price = priceAddEn[i].x;
            temp.GetComponent<Product>().AddEn = priceAddEn[i].y;
        }
    }
}
