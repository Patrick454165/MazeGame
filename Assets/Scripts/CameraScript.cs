using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}
