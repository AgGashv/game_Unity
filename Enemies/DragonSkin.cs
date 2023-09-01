using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkin : MonoBehaviour
{

    [SerializeField] private List<Material> materials = new List<Material>();


    void Start()
    {
        var renderer = GetComponent<Renderer>();

        renderer.material = materials[Random.Range(0, materials.Count)];
    }

}
