using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject poi;
    public float camMoveSpeed = 1;

    private float xPos;
    private float yPos;

    void Update()
    {
        xPos = Mathf.Lerp(transform.position.x, poi.transform.position.x, camMoveSpeed * Time.deltaTime);
        yPos = Mathf.Lerp(transform.position.y, poi.transform.position.y, camMoveSpeed * Time.deltaTime);

        transform.position = new Vector3(xPos, yPos, -10f);
    }
}
