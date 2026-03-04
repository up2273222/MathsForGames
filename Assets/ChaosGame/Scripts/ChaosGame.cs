using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;




namespace ChaosGame.Scripts
{
    public class ChaosGame : MonoBehaviour
    {
        [SerializeField] private int _particleCount;
        
        [SerializeReference] private FractalType _fractalType1;
        [SerializeReference] private FractalType _fractalType2;
        

        public ComputeShader chaosCompute;
        
        private ComputeBuffer PositionsBuffer1;
        private ComputeBuffer MatrixBuffer1;
        
        private ComputeBuffer PositionsBuffer2;
        private ComputeBuffer MatrixBuffer2;
        
        private Mesh _vertexMesh;
        public Material _vertexMaterial;

        private Bounds bounds;

        private int numGroups;
        
        private RenderParams rparams;

    

        private void OnEnable()
        {
            bounds = new Bounds(Vector3.zero, Vector3.one * 100000);
            numGroups = Mathf.CeilToInt((float)_particleCount / 256);
            
            rparams = new RenderParams(_vertexMaterial);
            rparams.matProps = new MaterialPropertyBlock();
            rparams.worldBounds = bounds;
            
            PositionsBuffer1 = new ComputeBuffer(_particleCount, (sizeof(float) * 3));
            PositionsBuffer2 = new ComputeBuffer(_particleCount, (sizeof(float) * 3));
            
            chaosCompute.SetBuffer (0,"_AttractorPoints1", PositionsBuffer1);
            chaosCompute.SetBuffer (0,"_AttractorPoints2", PositionsBuffer2);
            chaosCompute.SetInt("particleCount", _particleCount);
            chaosCompute.SetBuffer(1,"_AttractorPoints1",PositionsBuffer1);
            chaosCompute.SetBuffer(2,"_AttractorPoints2",PositionsBuffer2);
            
            

        }

        private void OnDisable()
        {
            PositionsBuffer1.Release();
            PositionsBuffer1 = null;
            
            MatrixBuffer1.Release();
            MatrixBuffer1 = null;
            
            PositionsBuffer2.Release();
            PositionsBuffer2 = null;
            
            MatrixBuffer2.Release();
            MatrixBuffer2 = null;
        }

        private void Start()
        {
            PopulateMatrixBuffer(ref MatrixBuffer1,_fractalType1);
            PopulateMatrixBuffer(ref MatrixBuffer2,_fractalType2);
            
            chaosCompute.Dispatch(0, numGroups, 1, 1);
            
            CreateAttractor1();
            CreateAttractor2();

            

        }

        private void Update()
        {
            Graphics.RenderPrimitives(rparams, MeshTopology.Points, _particleCount, 1);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                      rparams.matProps.SetBuffer("AttractorPointsBufferShader", PositionsBuffer1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    rparams.matProps.SetBuffer("AttractorPointsBufferShader", PositionsBuffer2);
                }
        }

        private void CreateAttractor1()
        {
            chaosCompute.SetInt("affineTransformationCount", _fractalType1.GetAffineMatrixCount());
            chaosCompute.SetBuffer(1,"_AttractorMatrices",MatrixBuffer1);
            
            for (int i = 0; i <12; i++)
            {
                chaosCompute.Dispatch(1,numGroups,1,1);
            }
            rparams.matProps.SetBuffer("AttractorPointsBufferShader", PositionsBuffer1);
          
          
        }

        private void CreateAttractor2()
        {
            chaosCompute.SetInt("affineTransformationCount", _fractalType2.GetAffineMatrixCount());
            chaosCompute.SetBuffer(2,"_AttractorMatrices",MatrixBuffer2);
            chaosCompute.SetBuffer(2,"_AttractorPoints2",PositionsBuffer2);
            for (int i = 0; i <12; i++)
            {
                chaosCompute.Dispatch(2,numGroups,1,1);
            }
          
        }


        private void PopulateMatrixBuffer(ref ComputeBuffer buffer, FractalType fractalType)
        {
            int matrixCount = fractalType.GetAffineMatrixCount();
            Matrix4x4[] matrixArray = fractalType.GetAffineMatrices();
            
            buffer = new ComputeBuffer(matrixCount, System.Runtime.InteropServices.Marshal.SizeOf(typeof(Matrix4x4)));
            buffer.SetData(matrixArray);
        }
    }
}
