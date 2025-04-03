using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.SceneManagement;
public class GenerateShape : MonoBehaviour
{
    private Color[] colorsArr = new Color[] { Color.red, Color.green, Color.blue };
    Color assignedColor;
    int multiply;
    int answer;
    private int numberOfSides;
    public GameObject prefab;
    public float instantiationYPosition = -10f;
    GameManager gameManager = new GameManager();
    
    // Range for random X and Z positions
    private float minX = 2.5f;
    private  float maxX = 100f;
    private  float minZ = 0f;
    private float maxZ = 100f;
    private float minY = 0f;
    private float maxY = 0f;
    string myTag;
    // Start is called before the first frame update
    void Start()
    {
        myTag = gameObject.tag;
        getColorNum();
        checkType();
        answer = multiply * numberOfSides;
        int newInt = answer + 10;
        int loop = newInt / 6;
        int  count = 0;
        while (count < 6) {
            for (int i = 0; i < loop; i++)
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                instantiateObjects();
            }
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfWin())
        {
            gameManager.LoadNextScene();
        }
        if (checkLoss())
        {
            SceneManager.LoadScene("LostScreen");
        }
    }
    public int getAnswer()
    {
        return answer;
    }
    int getColorNum()
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
        return multiply;
    }
    void checkType()
    {
        if (myTag != null )
        {

            if (myTag == "Cube")
            {
                numberOfSides = 12;
            }
            else if (myTag == "Quad")
            {
                numberOfSides = 4;
            }
            else if (myTag == "Sphere")
            {
                numberOfSides = (int)(0.5 * 3.14);
            }
            else //it will be cylinder with r =1 
            {
                numberOfSides = (int)(1* 3.14);
            }
        }
    }
    void instantiateObjects()
    {
        // Call this before random operations to set a new random seed
        //Random.InitState(System.DateTime.Now.Millisecond);
       // float randomX = Random.Range(minX, maxX);
        //float randomZ = Random.Range(minZ, maxZ);

        // Instantiate the object at the specified Y-axis position and random X-Z positions
        Random.InitState(System.DateTime.Now.Millisecond);
        Vector3 newPos = new Vector3(Random.Range(minX, maxX), minY, Random.Range(minZ, maxZ));
        GameObject instantiatedObj =  Instantiate(prefab,newPos , Quaternion.identity);
       
        instantiatedObj.tag="pickUpObj";
            instantiatedObj.AddComponent<PickUp>();

    }
    bool checkIfWin()
    {
        Debug.Log("counter: "+ PickUp.getCounter());
        Debug.Log("answer: " + answer);
        if(PickUp.getCounter() == getAnswer())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool checkLoss()
    {
        if(PickUp.getCounter() > answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
