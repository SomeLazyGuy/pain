using UnityEngine;

public class Door : MonoBehaviour
{
    public void OpenDoor()
    {
        Destroy(transform.GetChild(0).gameObject);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
