using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PickUp : MonoBehaviour
{
    private static int counter;
    private Scene currentScene;
    private GameObject player;
    private float distanceTreshold = 5f;
    private GameObject targetObject;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        resetCounter();
        // Find the first GameObject with the specified tag in the same scene
        player = GameObject.FindWithTag("Player");
        targetObject = GameObject.FindWithTag("Target");
        initialPosition = gameObject.transform.position;
    }
    public static int getCounter()
    {
        return counter;
    }
    public static void setCounter(int newCount)
    {
        counter = newCount;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            pickUp();
        }
        if (gameObject != null && Input.GetKey(KeyCode.R))
        { 
            removeFromTarget();
            counter = counter - 1;
        }
    }
    public static void resetCounter()
    {
        counter = 0;
    }
    void MoveToTarget()
    {
        if (targetObject != null)
        {
            Vector3 newPosition = targetObject.transform.position + new Vector3(0f, 0.5f, 0f);

            transform.position = newPosition;
        }
    }
    void removeFromTarget()
    {
        Vector3 newPosition = initialPosition;
        transform.position = newPosition;
        //setCounter(counter--);

    }
    /*void TryCollectObject()
    {
        if (IsVisible())
        {
            if (player != null && player.scene == currentScene)
            {
                // Cast a ray from the player's position in the forward direction
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10))
                {
                    // Check if the hit object has a script that can be collected
                    GameObject collectible = hit.collider.GetComponent<GameObject>();
                    if (collectible.CompareTag("Target"))
                    {
                        MoveToTarget(collectible);
                        counter++;
                    }
                    

                }
            }
        }
    }*/
    void pickUp()
    {
        if (IsVisible())
        {
            if(player != null && player.scene == currentScene)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (Input.GetKeyDown(KeyCode.Y) && distanceToPlayer< distanceTreshold)
                {

                    MoveToTarget();
                    counter++;
                   // setCounter(getCounter()+1);
                   /* GameObject gameObjToDeactivate = gameObject;
                    gameObject.SetActive(false);
                    if (gameObject.activeSelf)
                    {
                        Debug.Log("Game Object has not been collected");
                        
                    }
                    else
                    {
                        counter++;
                        MoveToTarget();
                        Debug.Log("You collected" + counter + "Objects");
                    }*/
                }
            }
          
       }  
    }
    bool IsVisible()
    {
        // Check if the GameObject is within the camera's frustum
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }
}
