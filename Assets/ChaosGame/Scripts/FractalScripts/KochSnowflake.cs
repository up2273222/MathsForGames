using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Fractals/KochSnowflake ")]
public class KochSnowflake : FractalType
{
    public KochSnowflake()
    {
        fractalName = "KochSnowflake ";
        affineMatrixCount = 7;
    }


    public override Matrix4[] GetAffineMatrices()
    {
        Matrix4[] affineMatrices = new Matrix4[affineMatrixCount];
        
        
        //Constants
        float oneOr3 = 1.0f / Mathf.Sqrt(3);


        affineMatrices[0] = MathCore.CreateAffineTransformMatrix(0, 0, oneOr3, oneOr3, 30);
        
        affineMatrices[1] = MathCore.CreateAffineTransformMatrix(oneOr3, 1/3f, 1/3f, 1/3f, 0);
        affineMatrices[2] = MathCore.CreateAffineTransformMatrix(0, 2/3f, 1/3f, 1/3f, 0);
        affineMatrices[3] = MathCore.CreateAffineTransformMatrix(-oneOr3, 1/3f, 1/3f, 1/3f, 0);
        affineMatrices[4] = MathCore.CreateAffineTransformMatrix(-oneOr3, -1/3f, 1/3f, 1/3f, 0);
        affineMatrices[5] = MathCore.CreateAffineTransformMatrix(0, -2/3f, 1/3f, 1/3f, 0);
        affineMatrices[6] = MathCore.CreateAffineTransformMatrix(oneOr3, -1/3f, 1/3f, 1/3f, 0);
        
        
        return affineMatrices;
    }
    
    
    
    
}