using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float x =  Mathf.Sin(Time.time ) / 1000;
        transform.position += new Vector3(
            10 * x,
            0,
            0);

        Debug.Log(x);
    }
}
