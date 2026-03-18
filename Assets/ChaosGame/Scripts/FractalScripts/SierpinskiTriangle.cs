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
        
        affineMatrices[0] = new Matrix4(
            new Vector4(0.5f,0,0,0),
            new Vector4(0, 0.5f,0,0), 
            new Vector4(0,0,0,0),
            new Vector4(0,0.36f,0,1));
        
        affineMatrices[1] = new Matrix4(
            new Vector4(0.5f,0,0,0),
            new Vector4(0, 0.5f,0,0), 
            new Vector4(0,0,0,0),
            new Vector4(-0.5f,-0.5f,0,1));
            
        affineMatrices[2] = new Matrix4(
            new Vector4(0.5f,0,0,0),
            new Vector4(0, 0.5f,0,0), 
            new Vector4(0,0,0,0),
            new Vector4(0.5f,-0.5f,0,1));
        
        
        
        return affineMatrices;
    }
    
}
