using Unity.Netcode;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : NetworkBehaviour
{
    [SerializeField] private float touchMovementSensitivity = 0.02f;
    private TouchControls touchControls;

    public override void OnNetworkSpawn()
    {
        if (IsHost)
        {
            gameObject.transform.position = new Vector3(0, 0, -4.8f);
        }
        else if (IsClient)
        {
            gameObject.transform.position = new Vector3(0, 0, 4.8f);
        }

        if (!IsOwner) return;

        touchControls = new TouchControls();
        touchControls.Enable();

        touchControls.Player.Slide.started += context => OnTouchSlided(context);
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) return;

        touchControls.Disable();
    }

    private void OnTouchSlided(CallbackContext context)
    {
        var position = transform.position;

        var touchInput = context.ReadValue<float>();

        if (!IsHost && IsClient)
        {
            touchInput *= -1;
        }

        position = new Vector3(position.x + touchInput * touchMovementSensitivity,
            position.y, position.z);

        position.x = Mathf.Clamp(position.x, -2.94f, 2.94f);

        transform.position = position;
    }
}
