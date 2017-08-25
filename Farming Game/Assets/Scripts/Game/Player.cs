using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtMethods {
    public static Vector3 Clamp( this Vector3 v, float min, float max ) {
        v.x = Mathf.Clamp( v.x, min, max );
        v.y = Mathf.Clamp( v.y, min, max );
        v.z = Mathf.Clamp( v.z, min, max );
        return v;
    }
    public static Vector3 Clamp( this Vector3 v, Vector3 min, Vector3 max ) {
        v.x = Mathf.Clamp( v.x, min.x, max.x );
        v.y = Mathf.Clamp( v.y, min.y, max.y );
        v.z = Mathf.Clamp( v.z, min.z, max.z );
        return v;
    }
}

public class Player : MonoBehaviour {

    public float Friction = 0.35f;
    public float Acceleration = 0.5f;
    public float MaxVelocity = 3f;
    public Vector3 Velocity;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if ( Input.GetKey( KeyCode.W ) ) Velocity.y += Acceleration;
        if ( Input.GetKey( KeyCode.S ) ) Velocity.y -= Acceleration;
        if ( Input.GetKey( KeyCode.D ) ) Velocity.x += Acceleration;
        if ( Input.GetKey( KeyCode.A ) ) Velocity.x -= Acceleration;

        if ( !Input.GetKey( KeyCode.W ) && !Input.GetKey( KeyCode.S ) ) Velocity.y = Mathf.Lerp( Velocity.y, 0, Friction );
        if ( !Input.GetKey( KeyCode.A ) && !Input.GetKey( KeyCode.D ) ) Velocity.x = Mathf.Lerp( Velocity.x, 0, Friction );

        if ( Velocity.x <= -MaxVelocity * 0.75 && Velocity.y <= -MaxVelocity * 0.75
             || Velocity.x <= -MaxVelocity * 0.75 && Velocity.y >= MaxVelocity * 0.75
             || Velocity.x >= MaxVelocity * 0.75 && Velocity.y <= -MaxVelocity * 0.75
             || Velocity.x >= MaxVelocity * 0.75 && Velocity.y >= MaxVelocity * 0.75 )
            Velocity = Velocity.Clamp( -MaxVelocity * 0.75f, MaxVelocity * 0.75f );
        else Velocity = Velocity.Clamp( -MaxVelocity, MaxVelocity );

        transform.position += Velocity * Time.deltaTime;
    }
}
