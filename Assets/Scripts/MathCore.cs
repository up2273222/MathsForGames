using System;
using UnityEngine;

public class MFGVector2
{
    public float x, y;

    public MFGVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public class MFGVector3
{
    public float x, y, z;

    public MFGVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public static class MathCore
{
    public static MFGVector2 AddVector2(MFGVector2 a, MFGVector2 b)
    {
        return new MFGVector2(a.x + b.x, a.y + b.y);
    }

    public static MFGVector2 SubtractVector2(MFGVector2 a, MFGVector2 b)
    {
        return new MFGVector2(a.x - b.x, a.y - b.y);
    }

    public static float MFGSqrt(float n)
    {
        if (n < 0.0f)
        {
            return 0.0f;
        }
        float x = n;
        float y = 1;
        
        double tolerance = 0.000001;
        while (x - y > tolerance)
        {
            x = (x + y) / 2;
            y = n / x;
        }
        
        return x;
    }

    public static float Vector2Len(MFGVector2 a)
    {
        return MathCore.MFGSqrt(a.x * a.x + a.y * a.y);
    }
    
    

    public static float MFGAbs(float a)
    {
        if (a > 0) return a;
        else return a * -1;
    }
    
    public static int MFGAbs(int a)
    {
        if (a > 0) return a;
        else return a * -1;
    }
    
    
    
    
}
