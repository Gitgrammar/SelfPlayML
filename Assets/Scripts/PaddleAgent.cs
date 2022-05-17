using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class PaddleAgent : Agent
{
    public int agentId;
    public GameObject ball;
    Transform ballTf;
    Rigidbody ballRb;
    void Start()
    {
        ballTf = ball.transform;
        ballRb = ball.GetComponent<Rigidbody>();
        
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        float dir = (agentId == 0) ?1.0f : -1.0f;
        sensor.AddObservation(ballTf.localPosition.x * dir);
        sensor.AddObservation(ballTf.localPosition.z * dir);
        sensor.AddObservation(ballRb.velocity.x * dir);
        sensor.AddObservation(ballRb.velocity.z * dir);
        sensor.AddObservation(transform.localPosition.x * dir);
    }
    private void OnCollisionEnter(Collision collision)
    {
        AddReward(0.1f);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float dir = (agentId == 0) ? 1.0f : -1.0f;
        int action = actions.DiscreteActions[0];
        Vector3 pos = transform.localPosition;
        if (action == 1)
        {
            pos.x -= 0.2f * dir;
        }else if (action == 2)
        {
            pos.x += 0.2f * dir;
        }
        if (pos.x < -4.0f) pos.x = -4.0f;
        if (pos.x > 4.0f) pos.x = 4.0f;
        transform.localPosition = pos;
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var action = actionsOut.DiscreteActions;
        action[0] = 0;
        if (Input.GetKey(KeyCode.LeftArrow))action[0] = 1;
        if (Input.GetKey(KeyCode.RightArrow)) action[0] = 2;


    }
}
    
        
    

