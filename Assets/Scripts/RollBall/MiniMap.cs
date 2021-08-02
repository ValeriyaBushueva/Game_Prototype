using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MiniMap : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        var main = Camera.main;
        player = main.transform;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90.0f, 0, 0);
        transform.position = player.position + new Vector3(0, 5.0f, 0);

        var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

        var component = GetComponent<Camera>();
        component.targetTexture = rt;
        component.depth = --main.depth;
    }

    
    void LateUpdate()
    {
        var newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90, player.eulerAngles.y, 0);
    }
}

// MVC
internal class MiniMapController
{
    private readonly Transform owner;
    private readonly Transform target;

    public MiniMapController(Transform owner, Transform target)
    {
        owner = this.owner;
        target = this.target;
    }

    public void LateExecute()
    {
        var newPosition = target.position;
        newPosition.y = owner.position.y;
        owner.position = newPosition;
        owner.rotation = Quaternion.Euler(90,target.eulerAngles.y, 0);
    }

}

internal class MiniMapInitialization
{
    private readonly Transform owner;
    private readonly Transform target;

    public MiniMapInitialization(Transform owner, Transform target)
    {
        owner = this.owner;
        target = this.target;
    }

    public void Initialization()
    {
        var main = Camera.main;
        owner.parent = null;
        owner.rotation = Quaternion.Euler(90.0f, 0,0);
        owner.position = target.position + new Vector3(0, 5.0f, 0);
        
        var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
        
        var component = owner.GetComponent<Camera>();
        component.targetTexture = rt;
        component.depth = --main.depth;
        
    }
}

 
