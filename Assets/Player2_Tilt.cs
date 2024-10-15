using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Tilt : Player2_Move
{
    public float ratio=5, maxAngle=15;
    protected override void Update()
    {
        base.Update();
        TiltBySpeed();
    }
    float GetSpeed()
    {
        return rb.velocity.x;
    }
    void TiltBySpeed()
    {
        float z = GetSpeed()*ratio;
        z = Mathf.Clamp(z, -maxAngle, maxAngle);
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
