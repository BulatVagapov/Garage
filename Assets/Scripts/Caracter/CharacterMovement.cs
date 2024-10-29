using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CharacterMovement : MonoBehaviour
{
    [Inject] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    public Vector3 Direction;

    public void SetDirection(InputAction.CallbackContext inputContext)
    {
        Direction = inputContext.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        if (rigidbody.velocity.sqrMagnitude >= (maxSpeed * maxSpeed)) return;

        rigidbody.AddRelativeForce(Direction * speed * Time.fixedDeltaTime, ForceMode.Force);
    }
}
