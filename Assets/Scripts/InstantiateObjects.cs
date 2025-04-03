using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    // Range for random X and Z positions
    public float minX = 2.5f;
    public float maxX = 100f;
    public float minZ = 0f;
    public float maxZ = 100f;
    public float minY = 0f;
    public float maxY = 0f;
    public GameObject prefab;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        GenerateShape newShape = new GenerateShape();
        instantiateObjects(number+10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void instantiateObjects(int number)
    {

        for (int i = 0; i < number; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            // Instantiate the object at the specified Y-axis position and random X-Z positions
            // Call this before your random operations to set a new random seed
            Random.InitState(System.DateTime.Now.Millisecond);
            GameObject instantiatedObj = Instantiate(prefab, new Vector3(randomX, minY, randomZ), Quaternion.identity);
            instantiatedObj.tag = "pickUpObj";
            instantiatedObj.AddComponent<PickUp>();
        }
    }
}
