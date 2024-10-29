using UnityEngine;

public class PickUpItemAction : AbstractAction
{
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layer;
    private RaycastHit hit;

    private bool actionIsAddeded;

    protected override string ActionString { get => actionString; }

    private string actionString = "E \n PickUp";

    protected override void DoAction()
    {
        player.Hand.PickUpItem(ref hit);
        RemoveActionFromPlayer();
    }

    protected override void AddActionToplayer()
    {
        base.AddActionToplayer();
        actionIsAddeded = true;
    }

    protected override void RemoveActionFromPlayer()
    {
        base.RemoveActionFromPlayer();
        actionIsAddeded = false;
    }

    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance, layer))
        {
            if (!actionIsAddeded) AddActionToplayer();
        }
        else
        {
            if (actionIsAddeded) RemoveActionFromPlayer();
        }
    }
}
