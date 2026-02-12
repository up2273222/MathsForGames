using UnityEngine;

public class PursuerController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed;
    private float minDist = 0.1f;




    private void Update()
    {

        if(MathCore.VectorDist(target.transform.position, this.gameObject.transform.position) >= minDist)
        {
            Vector3 dir = MathCore.SubtractVector(target.transform.position, this.gameObject.transform.position);
            this.gameObject.transform.position = MathCore.AddVector(this.gameObject.transform.position, MathCore.MoveStep(dir, speed, Time.deltaTime));
        }
        
    }
}
