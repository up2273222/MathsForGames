using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour

{

    [Header("Prefab")]

    public GameObject bulletPrefab;

    public Vector3 muzzleLocalOffset = new Vector3(0f, 0f, 1.2f);


    private bool firePressedThisFrame;


    // If you have PlayerInput (Send Messages) with a "Fire" action (you should after W3)

    public void OnFire(InputValue value)

    {

        firePressedThisFrame = value.Get<bool>();
        Debug.Log(firePressedThisFrame);

    }


    private void Update()

    {
        // 1) Basis vectors of the capsule (world space)

        Vector3 R = transform.right;

        Vector3 U = transform.up;

        Vector3 F = transform.forward;


        // 2) Capsule position

        Vector3 P = transform.position;


        // 3) Spawn position (local point -> world point)

        // TODO (C): Use the correct Part A function to convert muzzleLocalOffset into a world point.

        // Vector3 spawnPos = ...


        // 4) Fire direction (local direction -> world direction)

        // Local forward is (0,0,1)

        Vector3 localForward = new Vector3(0f, 0f, 1f);


        // TODO (C): Use the correct Part A function to convert localForward into a world direction and normalise it.

        // Vector3 fireDir = ...


        // 5) Spawn bullet (rotation is optional for movement)

        // TODO (C): GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);


        // 6) Pass direction to the bullet (Part D will implement BulletMover.Init)

        // TODO (C): bullet.GetComponent<Bullet>().Init(fireDir);

    }

}