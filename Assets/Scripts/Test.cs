
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*· Scale((2, -3, 1), 4) = (8, -12, 4)

· Divide((6, -2, 10), 2) = (3, -1, 5)

· Normalize((3, 4, 0)) ? (0.6, 0.8, 0.0)

· Dot((0,1,0), (0,1,0)) = 1

· Dot((0,1,0), (1,0,0)) = 0

· Dot((0,1,0), (0,-1,0)) = -1

· Normalize((0,0,0)) = (0,0,0) (no NaNs)
        */

        Debug.Log(MathCore.ScaleVector(new Vector3(2, -3, 1), 4));
        Debug.Log(MathCore.ScaleVector(new Vector3(6, -2, 10), 0.5f));
        Debug.Log(MathCore.NormaliseVector(new Vector3(3, 4, 0)));
        Debug.Log(MathCore.Dot(new Vector3(0, 1, 0), new Vector3(0, 1, 0)));
        Debug.Log(MathCore.Dot(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
        Debug.Log(MathCore.Dot(new Vector3(0, -1, 0), new Vector3(0, 1, 0)));
        Debug.Log(MathCore.NormaliseVector(Vector3.zero));

    }

    
    
}
