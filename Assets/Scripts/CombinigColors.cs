using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinigColors : MonoBehaviour
{
    public Material[] materials;

    void Start()
    {
        Color tempColor = new Color(0, 0, 0, 0);//combining colors from inspector

        for (int i = 0; i < materials.Length; i++)
        {
            tempColor  += materials[i].color;
        }

        this.GetComponent<MeshRenderer>().material.color = tempColor / materials.Length;
    }
}
