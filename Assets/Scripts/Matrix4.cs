using UnityEngine;

public class Matrix4
{
    public Vector4 row0;
    public Vector4 row1;
    public Vector4 row2;
    public Vector4 row3;

    public Matrix4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        row0 = new Vector4(column3.x, column1.x, column2.x, column4.x);
        row1 = new Vector4(column3.y, column1.y, column2.y, column4.y);
        row2 = new Vector4(column3.z, column1.z, column2.z, column4.z);
        row3 = new Vector4(        0,         0,         0,         1);
    }
}
