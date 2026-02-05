using UnityEngine;

namespace ChaosGame.Scripts
{
    public class ChaosGame : MonoBehaviour
    {
        [SerializeField] private uint numberOfPoints;
        [SerializeField] private Shader pointShader;

        private void CreatePointMeshes(uint numberOfPoints)
        {
            Mesh[] points = new Mesh[numberOfPoints];

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i] = new Mesh();
                
                
                
            }
            
        }
    }
}
