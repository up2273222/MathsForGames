using System.Collections.Generic;
using UnityEngine;

public abstract class FractalType : ScriptableObject
{
    [SerializeField]protected string fractalName;
    [SerializeField]protected int affineMatrixCount;
    public int GetAffineMatrixCount()
    {
        return affineMatrixCount;
    }
    
    public abstract Matrix4x4[] GetAffineMatrices();
}


