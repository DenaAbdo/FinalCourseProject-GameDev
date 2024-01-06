using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class GenerateShape : MonoBehaviour
{
    private Color[] colorsArr = new Color[] { Color.red, Color.green, Color.blue };
    Color assignedColor;
    int multiply;
    int answer;
    private int numberOfSides;
    public GameObject prefab;
    public float instantiationYPosition = -10f;

    // Range for random X and Z positions
    public float minX = 1f;
    public float maxX = 100f;
    public float minZ = 1f;
    public float maxZ = 100f;

    // Start is called before the first frame update
    void Start()
    {
        assignedColor = colorsArr[Random.Range(0, colorsArr.Length)];
        GetComponent<MeshRenderer>().material.color = assignedColor;

        if (assignedColor == Color.red)
        {
            multiply = 3;
        }
        else if (assignedColor == Color.green)
        {
            multiply = 5;
        }
        else if (assignedColor == Color.blue)
        {
            multiply = 4;
        }
        else
        {
            multiply = 1;
        }


        checkType();
        answer = multiply * numberOfSides;
        instantiateObjects(answer);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void checkType()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        // Check if the MeshFilter has a mesh and the mesh is a cube primitive
        if (meshFilter != null && meshFilter.sharedMesh != null)
        {

            if (meshFilter.sharedMesh.name.ToLower().Contains("cube"))
            {
                numberOfSides = 12;
            }
            else if (meshFilter.sharedMesh.name.ToLower().Contains("quad"))
            {
                numberOfSides = 4;
            }
            else //if(meshFilter.sharedMesh.name.ToLower().Contains("sphere"))
            {
                numberOfSides = 1;
            }
        }

    }
    void instantiateObjects(int number)
    {

            for(int i=0; i < number; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            // Instantiate the object at the specified Y-axis position and random X-Z positions
            // Call this before your random operations to set a new random seed
            Random.InitState(System.DateTime.Now.Millisecond);
            Instantiate(prefab, new Vector3(randomX, -2.5f, randomZ), Quaternion.identity);
        }
    }
}
