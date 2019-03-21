using UnityEngine;

public class fruits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "apple")
        {
            Destroy(gameObject);
        }
    }
}
