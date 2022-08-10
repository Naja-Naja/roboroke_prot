using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class robotpart:MonoBehaviour
{
    protected float weight;
    public virtual float Weight => this.weight;
    public virtual Vector2 VelocityUpdate(Vector2 nowVelovity,Quaternion angle)
    {
        return nowVelovity;
    }
    public virtual void Init() { }
}
