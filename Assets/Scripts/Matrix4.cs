using UnityEngine;

public struct Matrix4
{
    public Vector4 row0;
    public Vector4 row1;
    public Vector4 row2;
    public Vector4 row3;

    public Matrix4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        row0 = new Vector4(column1.x, column2.x, column3.x, column4.x);
        row1 = new Vector4(column1.y, column2.y, column3.y, column4.y);
        row2 = new Vector4(column1.z, column2.z, column3.z, column4.z);
        row3 = new Vector4(column1.w, column2.w, column3.w,    column4.w);
    }
}
