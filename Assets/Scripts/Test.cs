using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       print(MathCore.AddVector(new Vector2(2, 5),new Vector2(3, 0)));
       print(MathCore.SubtractVector(new Vector2(2, 5), new Vector2(5, 3)));
       print(MathCore.VectorLen(new Vector2(3,4)));
       print(MathCore.VectorDist(new Vector2(1,1), new Vector2(4,5)));
        
        
    }

    
    
}
