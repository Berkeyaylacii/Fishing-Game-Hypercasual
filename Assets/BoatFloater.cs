using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFloater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 0.5f;


    private void FixedUpdate()
    {
        float displacementMultiplier = Mathf.Clamp01((1.3f - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
        rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
    }
}
