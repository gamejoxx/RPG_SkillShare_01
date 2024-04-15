using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Tilemap tilemap;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;


    // Start is called before the first frame update
    void Start()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(2f, 2f, 0f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-2f, -2f, 0f);

        Player.instance.SetLimits(bottomLeftEdge, topRightEdge);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
