using System;
using UnityEngine;

namespace ChaosGame.Scripts
{
    public class ChaosGame : MonoBehaviour
    {
        //[SerializeField] private uint chaosGameCount;
        [SerializeField] private int chaosGameIterations;

        public ComputeShader chaosCompute;
        private ComputeBuffer attractorPositionsBuffer;
       

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
            
            attractorPositionsBuffer = new ComputeBuffer(chaosGameIterations, (sizeof(float) * 4));
            chaosCompute.SetBuffer (0,"_AttractorPoints", attractorPositionsBuffer);
            
            
            
            
        }

        private void OnDisable()
        {
            attractorPositionsBuffer.Release();
            attractorPositionsBuffer = null;
        }

        private void Update()
        {
            chaosCompute.Dispatch(0,numGroups,1,1);
            rparams.matProps.SetBuffer("AttractorPointsBufferShader", attractorPositionsBuffer);
            Graphics.RenderPrimitives(rparams, MeshTopology.Points, chaosGameIterations);
        }
    }
}
