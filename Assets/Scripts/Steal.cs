using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour
{
    public Transform targetObj;
    public float moveSpeed =5f;
    private float minDelay = 5f;
    private float maxDelay = 5f;
    private Vector3 initialPos;
    private Renderer foxRenderer;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoveToTargetRandomly());
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerAction();
    }
    private void checkPlayerAction()
    {
        if (Input.GetKey(KeyCode.K))
        {
            transform.position = initialPos;
            gameObject.SetActive(false);
        }
    }
    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, targetObj.position) > 0.1f)
        {
            gameObject.SetActive(true);
            if (audioSource != null)
            {
                audioSource.Play();
            }
            // Move towards the targetObject
            //transform.position = 
                Vector3.MoveTowards(transform.position, targetObj.position, moveSpeed * Time.deltaTime);
           
            // Wait for the next frame
            yield return null;
        }
    }
    private IEnumerator MoveToTargetRandomly()
    {
        foxRenderer.enabled = true;
        while (true)
        {
            // Wait for a random delay
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            // Move towards the targetObject
            
            StartCoroutine(MoveToTarget());
        }
    }
}
