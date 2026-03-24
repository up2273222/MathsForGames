using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Fractals/Sierpinski Triangle")]
public class SierpinskiTriangle : FractalType
{
    public SierpinskiTriangle()
    {
        fractalName = "SierpinskiTriangle";
        affineMatrixCount = 3;
    }


    public override Matrix4[] GetAffineMatrices()
    {
        Matrix4[] affineMatrices = new Matrix4[affineMatrixCount];
        
        affineMatrices[0] = MathCore.CreateAffineTransformMatrix(0, 0.36f, 0.5f, 0.5f, 0.0f);
        affineMatrices[1] = MathCore.CreateAffineTransformMatrix(-0.5f, -0.5f, 0.5f, 0.5f, 0.0f);
        affineMatrices[2] = MathCore.CreateAffineTransformMatrix(0.5f,-0.5f, 0.5f, 0.5f, 0.0f);
        
        
        
        
        return affineMatrices;
    }
    
}
