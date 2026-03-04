using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Fractals/Sierpinski Triangle")]
public class SierpinskiTriangle : FractalType
{
    public SierpinskiTriangle()
    {
        fractalName = "SierpinskiTriangle";
        affineMatrixCount = 3;
    }

    public override Matrix4x4[] GetAffineMatrices()
    {
        Matrix4x4[] affineMatrices = new Matrix4x4[affineMatrixCount];
        
        affineMatrices[0] = Matrix4x4.TRS(
            new Vector3(-0.5f, -0.5f, 0),
            Quaternion.identity,
            new Vector3(0.5f, 0.5f, 1)
        );
                                           
        affineMatrices[1] = Matrix4x4.TRS(
            new Vector3(0.5f, -0.5f, 0),
            Quaternion.identity,
            new Vector3(0.5f, 0.5f, 1)
        );
                
        affineMatrices[2] = Matrix4x4.TRS(
            new Vector3(0f, 0.36f, 0),
            Quaternion.identity,
            new Vector3(0.5f, 0.5f, 1)
        );
        return affineMatrices;
    }
    
}
