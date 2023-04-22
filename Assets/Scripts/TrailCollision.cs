using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailCollision : MonoBehaviour
{

    TrailRenderer myTrail;
    EdgeCollider2D myCollider;

    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();

        GameObject colliderGameObject = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        myCollider = colliderGameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for(int pos = 0; pos <trail.positionCount; pos++)
        {
            points.Add(trail.GetPosition(pos));
        }

        collider.SetPoints(points);
    }

    void OnDestroy()
    {
        Destroy(myCollider.gameObject);
    }
}
