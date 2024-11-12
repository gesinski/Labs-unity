using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedPlatforms : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    private const int PLATFORMS_NUM = 3;
    private GameObject[] platforms;
    private Vector2[] positions;
    private Vector2[] dstPositions= {new Vector2(-15,-5) };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PLATFORMS_NUM; i++)
        {

            //Vector2.MoveTowards(platforms[i].transform.position, )
        }
    }

    private void Awake()
    {
        platforms = new GameObject[PLATFORMS_NUM];
        positions = new Vector2[PLATFORMS_NUM];

        for (int i = 0; i < PLATFORMS_NUM; i++)
        {
            positions[i] = new Vector2(-15+i,-5+i);
            platforms[i] = Instantiate(platformPrefab, positions[i], Quaternion.identity);
        }
    }
}
