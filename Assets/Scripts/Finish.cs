using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            collision.GetComponent<Character>().finishWindow();
            gameObject.SetActive(false);
        }
    }
}
