using System;
using UnityEngine;

namespace Week1.Scripts
{
  public class Week1Player : MonoBehaviour
  {
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject player;
    [SerializeField] private float maxRange;
    public float currentdist;

    private void Update()
    {
      currentdist = MathCore.VectorDist(player.transform.position, target.transform.position);
      if (Input.GetKeyDown(KeyCode.Space))
      {
        if (currentdist <= maxRange)
        {
          transform.position = target.transform.position;
        }
      }
    }

    private void OnDrawGizmos()
    {
      if (currentdist <= maxRange)
      {
        Gizmos.color = Color.green;
      }
      else
      {
        Gizmos.color = Color.red;
      }
      Gizmos.DrawLine(player.transform.position, target.transform.position);
    }
  }
}
