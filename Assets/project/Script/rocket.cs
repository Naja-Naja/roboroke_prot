using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : robotpart
{
    public override float Weight => 5;
    float fuel;
    public override void Init()
    {
        fuel = 100;
        Debug.Log("initfuel");
    }
    public override Vector2 VelocityUpdate(Vector2 nowVelocity, Quaternion angle)
    {
        Vector2 newVelocity;
        if (fuel > 0)
        {
            float partangleRad = angle.eulerAngles.z * Mathf.Deg2Rad;
            float force = 0.3f;
            Vector2 addforce = new Vector2(Mathf.Cos(partangleRad) * force, Mathf.Sin(partangleRad) * force);
            Debug.Log("addforce" + addforce);
            newVelocity = nowVelocity + addforce;
            //newVelocity = new Vector2(nowVelocity.x + 0.05f, nowVelocity.y + 0.3f);
            fuel--;
        }
        else
        {
            newVelocity = nowVelocity;
        }
        return newVelocity;
    }
}
