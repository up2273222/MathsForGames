using UnityEngine;

public class TestQuat : MonoBehaviour
{
    private float angle;

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * 100;
        
        Quat q = new Quat(angle,new Vector3(0,1,0));

        Vector3 p = new Vector3(1, 2, 3);

        Quat k = new Quat(p);

        Quat newK = q * k * q.Inverse();

        Vector3 newP = newK.GetAxis();
        
        transform.position = newP;
    }
}
