using UnityEngine;

public class Turret : MonoBehaviour

{

    public Transform ship;

    public Vector3 localOffset = new Vector3(0f, -1f, 0f);


    private void LateUpdate()

    {

        // Get the ship basis vectors (these should be calculated and set in W3)

        Vector3 R = ship.right;

        Vector3 U = ship.up;

        Vector3 F = ship.forward;


        //Get ship position

        Vector3 P = ship.position;


        // TODO: Convert local offset -> world offset and apply to transform
        transform.position = MathCore.LocalPointToWorld(P,localOffset, U, F, R);

        // Then copy rotation

        transform.rotation = ship.rotation;

        

    }

}
