using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject poi;
    public float camMoveSpeed = 1;

    void Awake()
    {
        
    }

    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, poi.transform.position, camMoveSpeed * Time.deltaTime);
    }
}
