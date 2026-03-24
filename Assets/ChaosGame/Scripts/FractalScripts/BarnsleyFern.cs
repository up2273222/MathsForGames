using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Fractals/Barnsley Fern")]
public class BarnsleyFern : FractalType
{
    public BarnsleyFern()
    {
        fractalName = "Barnsley Fern";
        affineMatrixCount = 4;
    }

    public override Matrix4[] GetAffineMatrices()
    {
        
        Matrix4[] affineMatrices = new Matrix4[affineMatrixCount];
        
        affineMatrices[0] = new Matrix4(
            new Vector4(0f, 0f, 0f, 0f),
            new Vector4(0f, 0.16f, 0f, 0f),
            new Vector4(0f, 0f, 1f, 0f),
            new Vector4(0f, 0f, 0f, 1f));
            
        affineMatrices[1] = new Matrix4(
            new Vector4(0.85f, -0.04f, 0f, 0f),
            new Vector4(0.04f, 0.85f, 0f, 0f),
            new Vector4(0f, 0f, 1f, 0f),
            new Vector4(0f, 1.6f, 0f, 1f));
            
        affineMatrices[2] = new Matrix4(
            new Vector4(0.2f, 0.23f, 0f, 0f),
            new Vector4(-0.26f, 0.22f, 0f, 0f),
            new Vector4(0f, 0f, 1f, 0f),
            new Vector4(0f, 1.6f, 0f, 1f));
            
        affineMatrices[3] = new Matrix4(
            new Vector4(-0.15f, 0.26f, 0f, 0f),
            new Vector4(0.28f, 0.24f, 0f, 0f),
            new Vector4(0f, 0f, 1f, 0f),
            new Vector4(0f, 0.44f, 0f, 1f));
        
        return affineMatrices;
    }
 
 
}
