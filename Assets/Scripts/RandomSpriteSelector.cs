using UnityEngine;

public class RandomSpriteSelector : MonoBehaviour
{
    [SerializeField] GameObject blueBird;
    [SerializeField] GameObject redBird;
    [SerializeField] GameObject yellowBird;

    [Space, SerializeField] GameObject dayBackground;
    [SerializeField] GameObject nightBackground;

    [Space, SerializeField] GameObject dayPipe;
    [SerializeField] GameObject dayPipe1;
    [SerializeField] GameObject nightPipe;
    [SerializeField] GameObject nightPipe1;

    [Space, SerializeField] int birdRNG;
    [SerializeField] int backgroundRNG;

    private void Awake()
    {
        birdRNG = Random.Range(0,  3);
        backgroundRNG = Random.Range(0, 2);
    }
    private void Start()
    {
        switch (birdRNG)
        {
            case 0:
                blueBird.SetActive(true); break;
            case 1:
                redBird.SetActive(true); break;
            case 2:
                yellowBird.SetActive(true); break;
        }
        switch (backgroundRNG)
        {
            case 0:
                nightBackground.SetActive(true);
                nightPipe.SetActive(true);
                nightPipe1 .SetActive(true);
                break;
            case 1:
                dayBackground.SetActive(true); 
                dayPipe.SetActive(true);
                dayPipe1.SetActive(true);
                break;
        }
    }
}
