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

        

        public ComputeShader chaosCompute;
        
        struct FrustumPlane{
            public Vector3 normal;
            public float distance;
        };
        
        
     

        private GraphicsBuffer _argsBuffer;
        private GraphicsBuffer.IndirectDrawIndexedArgs[] _argsData;

        private GraphicsBuffer _visiblePointsBuffer;
       // private GraphicsBuffer _targetPointsBuffer;
        private GraphicsBuffer _currentPointsBuffer;
        private GraphicsBuffer _frustumBuffer;
        private GraphicsBuffer _matrixBuffer;

        private FrustumPlane[] _frustumPlanes;
        
        private Mesh _vertexMesh;
        public Material _vertexMaterial;

        private Bounds bounds;

        private int numGroups;
        
        private RenderParams rparams;
        [SerializeField] Camera _camera;

        private const int CommandCount = 1;

    

        private void OnEnable()
        {
            
            numGroups = Mathf.CeilToInt((float)_particleCount / 256);
            
        }

        private void OnDisable()
        {
            _visiblePointsBuffer.Release();
            _currentPointsBuffer.Release();
            _frustumBuffer.Release();
            _argsBuffer.Release();
            _matrixBuffer.Release();
            
            _visiblePointsBuffer = null;
            _currentPointsBuffer = null;
            _frustumBuffer = null;
            _argsBuffer = null;
            _matrixBuffer = null;
        }

        private void Start()
        {
            
            CreateBuffers();
        }

        private void Update()
        {
            chaosCompute.SetFloat("currentFrame", Time.frameCount);


          
            
            _frustumBuffer.SetData(CalculateFrustumPlanes());
           // _frustumBuffer.SetData(GeometryUtility.CalculateFrustumPlanes(_camera));
            
            
            
            
            
            
            chaosCompute.SetBuffer(2,"_FrustumPlanesBuffer", _frustumBuffer);
            chaosCompute.SetBuffer(2,"_VisiblePoints", _visiblePointsBuffer);
            chaosCompute.SetBuffer(2,"_ArgsBuffer", _argsBuffer);
            chaosCompute.SetBuffer(3,"_ArgsBuffer", _argsBuffer);
            
            
            
            
            
            //Reset instances
            chaosCompute.Dispatch(3,1,1,1);
            //Cull
            chaosCompute.Dispatch(2,numGroups,1,1);
            
            rparams.matProps.SetBuffer("AttractorPointsBufferShader", _visiblePointsBuffer);
            
            Graphics.RenderPrimitivesIndirect(rparams, MeshTopology.Points,_argsBuffer,CommandCount,0);
           
        }

    
        
            

        private void CreateBuffers()
        {
            //Define strides
            int maxInstanceCount = _particleCount;
            int instanceStride = sizeof(float) * 3;
            int frustumStride = sizeof(float) * 4;
            
            
            //Create all points buffer + buffer - culled points + frustum buffer
            _currentPointsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, maxInstanceCount, instanceStride);
            _visiblePointsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, maxInstanceCount, instanceStride);
            _frustumBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 6, frustumStride);


            //Create args buffer + set data
            _argsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, CommandCount,GraphicsBuffer.IndirectDrawIndexedArgs.size);
            _argsData = new GraphicsBuffer.IndirectDrawIndexedArgs[CommandCount];

            _argsData[0].indexCountPerInstance = 1;
            _argsData[0].startIndex = 0;
            _argsData[0].baseVertexIndex = 0;
            
            _argsBuffer.SetData(_argsData);
            
            //Create rparams
            rparams = new RenderParams(_vertexMaterial)
            {
                matProps = new MaterialPropertyBlock(),
                worldBounds = new Bounds(Vector3.zero, Vector3.one * 100000)
            };
            
            //Create affine matrices buffer
            int matrixCount = _fractalType1.GetAffineMatrixCount();
            Matrix4[] matrixArray = _fractalType1.GetAffineMatrices();

            _matrixBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, matrixCount, sizeof(float) * 4 * 4);
            _matrixBuffer.SetData(matrixArray);
        
        
            //Initialise Points
            chaosCompute.SetInt("particleCount", maxInstanceCount);
            chaosCompute.SetBuffer(0,"_CurrentPoints", _currentPointsBuffer);
            chaosCompute.Dispatch(0, numGroups, 1, 1);
            
            //Create the first attractor
            chaosCompute.SetInt("affineTransformationCount", _fractalType1.GetAffineMatrixCount());
            chaosCompute.SetBuffer(1,"_CurrentPoints",_currentPointsBuffer);
            chaosCompute.SetBuffer(1,"_AttractorMatrices",_matrixBuffer);
            
            
            for (int i = 0; i <20; i++)
            {
                chaosCompute.Dispatch(1,numGroups,1,1);
            }
            
            //Set cull kernel to have all points
            chaosCompute.SetBuffer(2,"_CurrentPoints", _currentPointsBuffer);
        }

        private FrustumPlane[] CalculateFrustumPlanes()
        {
            FrustumPlane[] outPlanes = new FrustumPlane[6];
        
            float aspect = _camera.aspect;
            float near = _camera.nearClipPlane;
            float far = _camera.farClipPlane;
            float fov = _camera.fieldOfView;
            
            float halfVSide = far * Mathf.Tan(fov / 2);
            float halfHDide = halfVSide * aspect;
            Vector3 frontMultFar = far * _camera.transform.forward;
            
            outPlanes[0].normal = _camera.transform.position + near * _camera.transform.forward;
            
          
            return outPlanes;
            
            
        }
        
    }
}
