using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Character : MonoBehaviour
{
    private PlayerInputActions playerInput;

    private CharacterMovement characterMovement;

    public Hand Hand { get; private set; }

    public UnityEvent PlayerAction;

    [Inject]
    public void Constract(PlayerInputActions playerInput, CharacterMovement characterMovement, Hand hand)
    {
        this.playerInput = playerInput;
        this.characterMovement = characterMovement;
        Hand = hand;
        playerInput.Enable();
    }

    void Start()
    {
        playerInput.Player.Move.performed += characterMovement.SetDirection;
        playerInput.Player.Action.performed += (value) => PlayerAction?.Invoke();
        Cursor.visible = false;
    }
}
