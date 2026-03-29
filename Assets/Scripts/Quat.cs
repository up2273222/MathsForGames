using System;
using UnityEngine;

public class Quat
{
    public float w, x, y, z;


    public Quat()
    {
        
    }
    
    public Quat(float w,float x, float y, float z)
    {
     this.w = w;
     this.x = x;
     this.y = y;
     this.z = z;   
    }

    public Quat(Vector3 v)
    {
        w = 0;
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public Quat(float theta, Vector3 v)
    {
        theta = MathCore.DegToRad(theta);

        v = MathCore.NormaliseVector(v);
        float halfTheta = theta * 0.5f;
        w = Mathf.Cos(halfTheta);
        x = v.x * Mathf.Sin(halfTheta);
        y = v.y * Mathf.Sin(halfTheta);
        z = v.z * Mathf.Sin(halfTheta);
    }

    public Vector3 GetAxis()
    {
        return new Vector3(x,y,z);
    }

    public void SetAxis(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    public Quat Inverse()
    {
        Quat rv = new Quat();
        rv.w = w;
        
        rv.SetAxis(-GetAxis());
        return rv;
    }

    public static Quat operator *(Quat lhs, Quat rhs)
    {
        float w = ((rhs.w * lhs.w) - MathCore.Dot(rhs.GetAxis(), lhs.GetAxis()));
        Vector3 v = MathCore.AddVector(MathCore.AddVector(
        MathCore.ScaleVector(lhs.GetAxis(),rhs.w),
        MathCore.ScaleVector(rhs.GetAxis(),lhs.w)),
        MathCore.Cross(lhs.GetAxis(), rhs.GetAxis()));
        return new Quat(w,v.x,v.y,v.z);
        
    }
    
    
}
