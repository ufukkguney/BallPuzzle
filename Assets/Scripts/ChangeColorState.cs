 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorState : MonoBehaviour
{
    private bool isCombine = false;
    private bool isTriggerHere = false;

    private void OnTriggerEnter(Collider ball)
    {
        if (ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount > 0 )//check for combining color
        {
            ChangeColorDirect(ball);
            if (ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount == 1)
            {
                ChangeColorState[] changeColorStates = this.transform.parent.GetComponentsInChildren<ChangeColorState>();
                for (int i = 0; i < changeColorStates.Length; i++)
                {
                    changeColorStates[i].isCombine = false;
                }
                isCombine = true;
            }
        }
        else
        {
            if (!isCombine && ball.transform.GetComponent<MeshRenderer>().material.color != this.transform.GetComponent<MeshRenderer>().material.color)
            {
                CombiningColorToPlayer(ball);
                isCombine = true;
            }
        }
        //Debug.Log("CanCombiningAmount : " + ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount);

        //if (this.GetComponent<MeshRenderer>().material.color == Color.white)
        //{
        //    Debug.Log("CAncombiningAmount : " + ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount);
        //    if (ball.transform.GetComponent<BallMovementJoystick>().cancombiningAmount < 1)
        //    {
        //        ChangeColorDirect(ball);

        //        ChangeColorState[] changeColorStates = this.transform.parent.GetComponentsInChildren<ChangeColorState>();

        //        Debug.Log(changeColorStates.Length);
        //        for (int i = 0; i < changeColorStates.Length; i++)
        //        {
        //            changeColorStates[i].isCombine = false;
        //        }
        //    }
        //}
    }

    private void ChangeColorDirect(Collider ball)
    {
        ball.transform.GetComponent<MeshRenderer>().material.color = this.transform.GetComponent<MeshRenderer>().material.color;
        ParticleSystem.MainModule ma = ball.transform.GetComponent<ParticleSystem>().main;
        ma.startColor = this.transform.GetComponent<MeshRenderer>().material.color;
    }
    private void CombiningColorToPlayer(Collider ball)
    {
        ball.transform.GetComponent<MeshRenderer>().material.color =
                (ball.transform.GetComponent<MeshRenderer>().material.color +
                    this.transform.GetComponent<MeshRenderer>().material.color) / 2;

        ParticleSystem.MainModule ma = ball.transform.GetComponent<ParticleSystem>().main;

        ma.startColor = 
            (ball.transform.GetComponent<MeshRenderer>().material.color +
                    this.transform.GetComponent<MeshRenderer>().material.color) / 2;
    }

}
