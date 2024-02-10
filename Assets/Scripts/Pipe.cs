using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private float speed;
    [SerializeField]
    private float timeToDestroyPipe;
    private void Start()
    {
        StartCoroutine(AutoDestroyPipe());  
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private IEnumerator AutoDestroyPipe()
    {
        yield return new WaitForSeconds(timeToDestroyPipe);

        Destroy(this.gameObject);
    }
}
