using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ChaosGame.Scripts
{
    public class ChaosGame : MonoBehaviour
    {
        //[SerializeField] private uint chaosGameCount;
        [SerializeField] private int chaosGameIterations;

        public ComputeShader chaosCompute;
        private ComputeBuffer attractorPositionsBuffer;

        private Matrix4x4[] matrixArray;
        private ComputeBuffer matrixBuffer;
        
        public Vector3[] positions;
       

        private Mesh _vertexMesh;
        public Material _vertexMaterial;

        private Bounds bounds;

        private int numGroups;
        
        private RenderParams rparams;

        public Mesh testmesh;
        

        private void Awake()
        {
       
          
           
            
        }

        private void OnEnable()
        {
            bounds = new Bounds(Vector3.zero, Vector3.one * 100000);
            numGroups = Mathf.CeilToInt((float)chaosGameIterations / 256);
            
            rparams = new RenderParams(_vertexMaterial);
            rparams.matProps = new MaterialPropertyBlock();
            rparams.worldBounds = bounds;
            
            attractorPositionsBuffer = new ComputeBuffer(chaosGameIterations, (sizeof(float) * 3));
            chaosCompute.SetBuffer (0,"_AttractorPoints", attractorPositionsBuffer);
            chaosCompute.SetInt("iterationCount", chaosGameIterations);
            
            
            
           
            







        }

        private void OnDisable()
        {
            attractorPositionsBuffer.Release();
            attractorPositionsBuffer = null;
            
            matrixBuffer.Release();
            matrixBuffer = null;
        }

        private void Start()
        {
            CreateAttractor();

        }

        private void Update()
        {
                Graphics.RenderPrimitives(rparams, MeshTopology.Points, chaosGameIterations,1);
        }

        private void CreateAttractor()
        {
            PopulateMatrixBuffer();
            
            chaosCompute.SetBuffer(1,"_AttractorMatrices",matrixBuffer);
            
            chaosCompute.Dispatch(0,numGroups,1,1);
            
            chaosCompute.SetBuffer(1,"_AttractorPoints",attractorPositionsBuffer);
            

            for (int i = 0; i < 8; i++)
            {
                chaosCompute.Dispatch(1,numGroups,1,1);
            }
            chaosCompute.SetBuffer(2, "_AttractorPoints", attractorPositionsBuffer);
            chaosCompute.Dispatch(2,numGroups,1,1);
            rparams.matProps.SetBuffer("AttractorPointsBufferShader", attractorPositionsBuffer);
        }


        private void PopulateMatrixBuffer()
        {
            matrixArray = new Matrix4x4[3];
            
            matrixArray[0] = Matrix4x4.TRS(
                new Vector3(-0.5f, -0.5f, 0),
                Quaternion.identity,
                new Vector3(0.5f, 0.5f, 1)
            );
                                           
            matrixArray[1] = Matrix4x4.TRS(
                new Vector3(0.5f, -0.5f, 0),
                Quaternion.identity,
                new Vector3(0.5f, 0.5f, 1)
            );
                
            matrixArray[2] = Matrix4x4.TRS(
                new Vector3(0f, 0.36f, 0),
                Quaternion.identity,
                new Vector3(0.5f, 0.5f, 1)
            );

            matrixBuffer = new ComputeBuffer(3, System.Runtime.InteropServices.Marshal.SizeOf(typeof(Matrix4x4)));
            matrixBuffer.SetData(matrixArray);
        }
    }
}
