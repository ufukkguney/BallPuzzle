using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObstacle : MonoBehaviour
{
    private bool isOpen = false;
    public bool upAnimation, downAnimation, rightAnimation, leftAnimation,forwardAnimation,backAnimation;


    private void OnTriggerEnter(Collider ball)//when ball came the lock cube open the obstacle
    {
        if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && leftAnimation)
        {
            AnimationMovement(-10, 0, 0, ball);
        }
        else if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && rightAnimation)
        {
            AnimationMovement(10, 0, 0, ball);
        }
        if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && upAnimation)
        {
            AnimationMovement(0, 5, 0, ball);
        }
        else if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && downAnimation)
        {
            AnimationMovement(0, -5, 0, ball);
        }
        if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && forwardAnimation)
        {
            AnimationMovement(0, 0, 5, ball);
        }
        else if (ball.transform.GetComponent<MeshRenderer>().material.color == this.transform.GetComponent<MeshRenderer>().material.color && !isOpen && backAnimation)
        {
            AnimationMovement(0, 0, -5, ball);
        }


    }

    public void AnimationMovement(float xValue, float yValue, float zValue, Collider ball)
    {
        StartCoroutine(MoveObject(transform.GetChild(0).position, new Vector3(transform.GetChild(0).position.x + xValue, transform.GetChild(0).position.y + yValue, transform.GetChild(0).position.z + zValue), 3f));
        isOpen = true;

        ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount -= 1;// if cancombining amount == 0 -> do combine colors
    }

    IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)//obstacle opening with lerp
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.GetChild(0).position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.GetChild(0).position = target;
    }
}
