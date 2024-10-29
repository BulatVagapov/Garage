using UnityEngine;
using Zenject;

public class Hand : MonoBehaviour
{
    [Inject] private PickUpItemAction pickUpAction;
    
    public bool ItemInHend { get; private set; }

    private RaycastHit pickedUpItem;

    public void PickUpItem(ref RaycastHit item)
    {
        pickedUpItem = item;

        if (pickedUpItem.transform == null) return;
        pickedUpItem.transform.position = transform.position;
        pickedUpItem.transform.parent = transform;

        ItemInHend = true;
        pickUpAction.enabled = false;
    }

    public void DropItem(Transform pickUp)
    {
        pickedUpItem.transform.parent = pickUp;
        pickedUpItem.transform.position = pickUp.position;

        ItemInHend = false;
        pickedUpItem = new();
        pickUpAction.enabled = true;
    }
}
