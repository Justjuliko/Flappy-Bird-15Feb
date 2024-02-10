using System.Collections;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private float speed;
    [SerializeField]
    private float timeToDestroyPipe;

    [Space, SerializeField]
    float pipeSpawnHorizontalPos;
    [SerializeField]
    private Transform pipeMaxHeight;
    [SerializeField]
    private Transform pipeMinHeight;
    private void Start()
    {
        StartCoroutine(AutoDestroyPipe());  
    }
    void Update()
    {
        if(GameManager.Instance.IsGameOver)
        {
            return;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private IEnumerator AutoDestroyPipe()
    {
        do
        {
            yield return new WaitForSeconds(timeToDestroyPipe);

            transform.position = new Vector3(pipeSpawnHorizontalPos, GetPipeHeight(), 0);
            timeToDestroyPipe = 3;
        } while (true);
    }
    public float GetPipeHeight()
    {
        return UnityEngine.Random.Range(pipeMinHeight.position.y, pipeMaxHeight.position.y);
    }
}
