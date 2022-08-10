using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class robotmove : MonoBehaviour
{
    [SerializeField]bool player = true;
    bool gamestart=false;
    [SerializeField]
    robotpartdata robotPartData;
    [SerializeField] Rigidbody2D rb2d;
    int activePart = 0;
    public ReactiveProperty<float> distance;
    public List<robotpart> partsList;
    public List<Quaternion> partsangle;
    void Start()
    {
        //rocket test = new rocket();
        //test.VelocityUpdate(Vector2.zero);
        //robotpart test2 = test;
        //robotPartData.partsList[0].VelocityUpdate(Vector2.one);
        //Debug.Log(robotPartData.partsList[0].VelocityUpdate(Vector2.zero));
        //var test = robotPartData.GetRobotparts();
        //test[0] = null;
        //Debug.Log(test[0]);
        partsList = robotPartData.GetRobotparts();
        partsangle = robotPartData.GetQuaternions();
        robotPartData.partsList[activePart].Init();
        Invoke("GameStart", 1f);
    }

    void GameStart()
    {
        gamestart = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changepart();
        }
        distance.Value = this.transform.position.x;
    }
    public void changepart()
    {
        if (partsList.Count - 1 == activePart) { }
        else
        {
            activePart++;
            partsList[activePart].Init();
        }
    }
    private void FixedUpdate()
    {
        if (gamestart == true)
        {
            Vector2 nowVelocity = rb2d.velocity;
            Vector2 newVelocity = 
                partsList[activePart].VelocityUpdate(
                    nowVelocity,
                    partsangle[activePart]
                    );
            rb2d.velocity = newVelocity;
            //Debug.Log(rb2d.velocity);
        }
    }
    public void Restart()
    {
        rb2d.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(-1, 3);
        activePart = 0;
        partsList[activePart].Init();
        Invoke("GameStart", 1f);
    }
}
