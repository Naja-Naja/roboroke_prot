using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : robotpart
{
    public override float Weight => 5;
    float fuel;
    public override void Init()
    {
        fuel = 1;
        Debug.Log("initfuel");
    }
    public override Vector2 VelocityUpdate(Vector2 nowVelocity, Quaternion angle)
    {
        Vector2 newVelocity;
        if (fuel > 0)
        {
            float partangleRad = angle.eulerAngles.z * Mathf.Deg2Rad;
            Debug.Log(partangleRad);
            float force = 15;
            Vector2 addforce= new Vector2(Mathf.Cos(partangleRad) *force, Mathf.Sin(partangleRad)*force);
            Debug.Log("addforce"+addforce);
            //newVelocity = new Vector2(nowVelocity.x + 10f, nowVelocity.y + 8f);
            newVelocity = nowVelocity + addforce;
            fuel--;
        }
        else
        {
            newVelocity = nowVelocity;
        }
        return newVelocity;
    }
}
