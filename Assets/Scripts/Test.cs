
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;


public class Test : MonoBehaviour
{

    void Start()
    {
    
    
        //Q2   
        
        /*
        Vector4 R = new Vector4(0.2f, 0, -0.98f,0);
        Vector4 U = new Vector4(0, 1, 0,0);
        Vector4 F = new Vector4(0.98f, 0, 0.2f,0);
        Vector4 P = new Vector4(3, 5, -2,1);
        
        Matrix4 outm = new Matrix4(R, U, F, P);
        Debug.Log(outm.row0);
        Debug.Log(outm.row1);
        Debug.Log(outm.row2);
        Debug.Log(outm.row3);*/
        
        //RUFP

        
        
        
        //Q3
        
        /*
        Vector3 P = new Vector3(8, 1, -4);
        
        Vector4 WorldP = new Vector4(-8, 1, -4,1);
        Vector4 DirectionP = new Vector4(-8, 1, -4,0);

        Vector3 localV = new Vector3(2, -1, 3);

        Vector3 R = new Vector3(1, 0, 0);
        Vector3 U = new Vector3(0, 1, 0);
        Vector3 F= new Vector3(0, 0, 1);



        Debug.Log(P + localV);
        */








        //Q4
        
        /*
        Vector3 R = new Vector3(0.6f,0,-0.8f);
        Vector3 U = new Vector3(0, 1, 0);
        Vector3 F = new Vector3(0.8f, 0, 0.6f);

        Vector3 scale = new Vector3(3, 2, 0.5f);

        R *= scale.x;
        U *= scale.y;
        F *= scale.z;

        Debug.Log(R);
        Debug.Log(U);
        Debug.Log(F);*/






        
        //Q5
        float yawDeg = 30;
        float pitchDeg = 20;

        float yawRad = MathCore.DegToRad(yawDeg);
        float pitchRad = MathCore.DegToRad(pitchDeg);

        Vector3 Forward = MathCore.ForwardFromYawPitch(yawRad, pitchRad);
        Debug.Log(Forward);

        Vector3 WorldUp = new Vector3(0, 1, 0);

        Vector3 Right = MathCore.Cross(WorldUp, Forward);
        Right = MathCore.NormaliseVector(Right);

        Debug.Log(Right);

        Vector3 Scale = new Vector3(2,1.5f,0.5f);
        Vector4 translation = new Vector4(4, -2, 7,1);

        Right *= Scale.x;
        WorldUp *= Scale.y;
        Forward *= Scale.z;

        Matrix4 m = new Matrix4(Right,WorldUp,Forward,translation);

        Vector4 localPoint =  new Vector4(1,0,2,1);
        Vector4 localDirection = new Vector4(1,0,2,0);

        Vector3 final1;
        Vector3 final2;

       final1 = MathCore.Mul(m,localDirection);
       final2 = MathCore.Mul(m,localPoint);
       
       Debug.Log((float)final1.x);
       Debug.Log((float)final1.y);
       Debug.Log((float)final1.z);
       
       Debug.Log((float)final2.x);
       Debug.Log((float)final2.y);
       Debug.Log((float)final2.z);

        







    //Q9 = 10.4










    }



}
