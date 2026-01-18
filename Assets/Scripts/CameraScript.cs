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
        //Makes sure the camera is on top of the player
        transform.position = new(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}
