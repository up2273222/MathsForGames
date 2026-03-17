using System;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.PlayerLoop;


public static class MathCore
{
    private const float MATHCORE_PI = 3.14159265359f;
    //Vector 2----------------------------------------------------

    public static Vector2 AddVector(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static Vector2 SubtractVector(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }
    
    public static float VectorLen(Vector2 a)
    {
        return Mathf.Sqrt(a.x * a.x + a.y * a.y);
    }

    public static float VectorDist(Vector2 start, Vector2 end)
    {
        return MathCore.VectorLen(SubtractVector(start, end));
    }

    public static Vector2 ScaleVector(Vector2 a, float scale)
    {
        return new Vector2(a.x * scale, a.y * scale);
    }

    public static Vector2 NormaliseVector(Vector2 a)
    {
        float len = MathCore.VectorLen(a);
        if (len == 0) { return new Vector2(0, 0); }
        return new Vector2(a.x / len, a.y / len);
    }

    public static float Dot(Vector2 a, Vector2 b)
    {
        return (a.x * b.x) + (a.y * b.y);
    }

    
    public static Vector2 MoveStep(Vector2 direction, float speed, float deltaTime)
    {
        direction = MathCore.NormaliseVector(direction);
        Vector2 velocity = MathCore.ScaleVector(direction, speed);
        return MathCore.ScaleVector(velocity, deltaTime);
    }


    /// Returns radians
    public static float AngleFromVector2(Vector2 a)
    {
        
        return Mathf.Atan2(a.y, a.x);
    }

    public static Vector2 Vector2FromAngle(float rad)
    {
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
    

    //Vector 3----------------------------------------------------

    public static Vector3 AddVector(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3 SubtractVector(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static float VectorLen(Vector3 a)
    {
        return Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
    }

    public static float VectorDist(Vector3 start, Vector3 end)
    {
        return MathCore.VectorLen(SubtractVector(start, end));
    }

    public static Vector3 ScaleVector(Vector3 a, float scale)
    {
        return new Vector3(a.x * scale, a.y * scale, a.z * scale);
    }

    public static Vector3 NormaliseVector(Vector3 a)
    {
        float len = MathCore.VectorLen(a);
        if (len == 0) { return new Vector3(0, 0, 0); }
        return new Vector3(a.x / len, a.y / len, a.z /len);
    }

    public static float Dot(Vector3 a, Vector3 b)
    {
        return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
    }

    public static Vector3 MoveStep(Vector3 direction, float speed, float deltaTime)
    {
        direction = MathCore.NormaliseVector(direction);
        Vector3 velocity = MathCore.ScaleVector(direction,speed);
        return MathCore.ScaleVector(velocity,deltaTime);
    }

    public static Vector3 ForwardFromYawPitch(float yawRad, float pitchRad)
    {
        return new Vector3(
            (float)(Math.Sin(yawRad) * Math.Cos(pitchRad)),
            (float)Math.Sin(pitchRad),
            (float)(Math.Cos(yawRad) * Math.Cos(pitchRad)));
    }

    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        return new Vector3(
            (a.y * b.z - a.z * b.y),
            (a.z * b.x - a.x * b.z),
            (a.x * b.y - a.y * b.x));
    }

    public static Vector3 DirectionFromBasis(Vector3 localDir, Vector3 up, Vector3 forward, Vector3 right)
    {
        return MathCore.AddVector(
            MathCore.AddVector(MathCore.ScaleVector(right, localDir.x), MathCore.ScaleVector(up, localDir.y)),
            MathCore.ScaleVector(forward, localDir.z));
    }

    public static Vector3 LocalPointToWorld(Vector3 p, Vector3 localPoint, Vector3 up, Vector3 forward, Vector3 right)
    {
        return MathCore.AddVector(DirectionFromBasis(localPoint, up, forward, right), p);
    }
    
    
    //Vector 4
    public static float Dot(Vector4 a, Vector4 b)
    {
        return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
    }
    
    //Matrix 4x4

    public static void BasisFromForward(Vector3 forwardIn, out Vector3 up, out Vector3 forward, out Vector3 right)
    {
        forward = MathCore.NormaliseVector(forwardIn);
        up = new Vector3(0, 1, 0);
        right = MathCore.NormaliseVector(MathCore.Cross(up, forward));
        up = MathCore.Cross(forward, right);
    }
    

    //Standard math operations-------------------------------------

    public static float MFGAbs(float a)
    {
        if (a > 0) return a;
        return a * -1;
    }
    
    public static int MFGAbs(int a)
    {
        if (a > 0) return a;
        return a * -1;
    }

    public static float DegToRad(float deg)
    {
        return deg * (MATHCORE_PI / 180f);
    }

    public static float RadToDeg(float rad)
    {
        return rad * (180 / MATHCORE_PI);
    }

    
    //Unused --------------------------------------------------------
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
    
    
    
    
}
