float4 MathCoreMul(float4x4 inMatrix,float4 inPos)
{
    float4 outPos = 0.0f;
    outPos.x = inMatrix[0].x * inPos.x + inMatrix[0].y * inPos.y + inMatrix[0].z * inPos.z + inMatrix[0].w * inPos.w;
    outPos.y = inMatrix[1].x * inPos.x + inMatrix[1].y * inPos.y + inMatrix[1].z * inPos.z + inMatrix[1].w * inPos.w;
    outPos.z = inMatrix[2].x * inPos.x + inMatrix[2].y * inPos.y + inMatrix[2].z * inPos.z + inMatrix[2].w * inPos.w;
    outPos.w = inMatrix[3].x * inPos.x + inMatrix[3].y * inPos.y + inMatrix[3].z * inPos.z + inMatrix[3].w * inPos.w;
    return outPos;
}