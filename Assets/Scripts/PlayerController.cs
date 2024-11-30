// PlayerController.cs
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3f; // Distance between lanes
    private bool isLeftLane = true;
    private Vector3 targetPosition;
    
    void Start()
    {
        targetPosition = transform.position;
    }
    
    void Update()
    {
        // Basic forward movement
        transform.Translate(Vector3.forward * GameManager.Instance.gameSpeed * Time.deltaTime);
        
        // Lane switching
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchLane(true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchLane(false);
        }
        
        // Smooth lane movement
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(targetPosition.x, transform.position.y, transform.position.z), 
            Time.deltaTime * 10f);
    }
    
    void SwitchLane(bool goLeft)
    {
        if (goLeft && !isLeftLane)
        {
            targetPosition = new Vector3(-laneDistance/2, transform.position.y, transform.position.z);
            isLeftLane = true;
        }
        else if (!goLeft && isLeftLane)
        {
            targetPosition = new Vector3(laneDistance/2, transform.position.y, transform.position.z);
            isLeftLane = false;
        }
    }
}