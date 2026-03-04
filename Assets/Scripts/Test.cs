
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Test : MonoBehaviour
{

    void Start()
    {
        Vector3 upworld = new Vector3(0, 1, 0);
        Vector3 fwsd = new Vector3(0.6634f, 0.5000f, 0.5567f);
        
        Vector3 right = Vector3.Cross(upworld, fwsd);
        right.Normalize();
        
        Debug.Log(right);




    }



}
