using UnityEngine;

public class CoinScript : MonoBehaviour 
{
    float wait = 0.3f;
    public GameObject Coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    // Update is called once per frame
    void Fall()
    {
        Instantiate(Coin, new Vector3(Random.Range(-10, 10), 10, 0), Quaternion.identity);
    }
}
