using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            collision.gameObject.GetComponent<Character>().isDetected();
        }
    }
}