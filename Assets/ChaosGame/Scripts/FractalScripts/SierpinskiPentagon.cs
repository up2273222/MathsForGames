using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Fractals/SierpinskiPentagon ")]
public class SierpinskiPentagon : FractalType
{
    
    public SierpinskiPentagon()
    {
        fractalName = "SierpinskiPentagon";
        affineMatrixCount = 5;
        
    }


    public override Matrix4[] GetAffineMatrices()
    {
        Matrix4[] affineMatrices = new Matrix4[affineMatrixCount];

        
        float scale = (3 - Mathf.Sqrt(5)) / 2;

        affineMatrices[0] = MathCore.CreateAffineTransformMatrix(0, 0, scale, scale, 0);
        
        affineMatrices[1] = MathCore.CreateAffineTransformMatrix(0.618f, 0, scale, scale, 0);
        affineMatrices[2] = MathCore.CreateAffineTransformMatrix(0.809f, 0.588f, scale, scale, 0);
        affineMatrices[3] = MathCore.CreateAffineTransformMatrix(0.309f, 0.951f, scale, scale, 0);
        affineMatrices[4] = MathCore.CreateAffineTransformMatrix(-0.191f, 0.588f, scale, scale, 0);
        

      
        
        
        
 
        
        return affineMatrices;
    }
    
    
    
    
}