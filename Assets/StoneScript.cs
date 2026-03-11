using UnityEngine;

public class StoneScript : MonoBehaviour
{
    float wait = 0.15f;
    public GameObject Stone; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    // Update is called once per frame
    void Fall()
    {
        Instantiate(Stone, new Vector3(Random.Range(-10, 10), 10, 0), Quaternion.identity);
    }
}
