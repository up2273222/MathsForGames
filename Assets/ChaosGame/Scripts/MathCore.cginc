struct MathCoreM4x4
{
float4 row0,row1,row2,row3;
};

MathCoreM4x4 Create4x4(float4 col0, float4 col1, float4 col2, float4 col3)
{
    MathCoreM4x4 m;
    m.row0 = float4(col0.x, col1.x, col2.x, col3.x);
    m.row1 = float4(col0.y, col1.y, col2.y, col3.y);
    m.row2 = float4(col0.z, col1.z, col2.z, col3.z);
    m.row3 = float4(col0.w, col1.w, col2.w, col3.w);
    return m;
}



float4 MathCoreMul(MathCoreM4x4 inMatrix, float4 inPos)
{
float4 outPos = 0.0f;
    outPos.x = inMatrix.row0.x * inPos.x + inMatrix.row0.y * inPos.y + inMatrix.row0.z * inPos.z + inMatrix.row0.w * inPos.w;
    outPos.y = inMatrix.row1.x * inPos.x + inMatrix.row1.y * inPos.y + inMatrix.row1.z * inPos.z + inMatrix.row1.w * inPos.w;
    outPos.z = inMatrix.row2.x * inPos.x + inMatrix.row2.y * inPos.y + inMatrix.row2.z * inPos.z + inMatrix.row2.w * inPos.w;
    outPos.w = inMatrix.row3.x * inPos.x + inMatrix.row3.y * inPos.y + inMatrix.row3.z * inPos.z + inMatrix.row3.w * inPos.w;
    return outPos;


}

float4 MathCoreMul(float4x4 inMatrix,float4 inPos)
{
    float4 outPos = 0.0f;
    outPos.x = inMatrix[0].x * inPos.x + inMatrix[0].y * inPos.y + inMatrix[0].z * inPos.z + inMatrix[0].w * inPos.w;
    outPos.y = inMatrix[1].x * inPos.x + inMatrix[1].y * inPos.y + inMatrix[1].z * inPos.z + inMatrix[1].w * inPos.w;
    outPos.z = inMatrix[2].x * inPos.x + inMatrix[2].y * inPos.y + inMatrix[2].z * inPos.z + inMatrix[2].w * inPos.w;
    outPos.w = inMatrix[3].x * inPos.x + inMatrix[3].y * inPos.y + inMatrix[3].z * inPos.z + inMatrix[3].w * inPos.w;
    return outPos;
}