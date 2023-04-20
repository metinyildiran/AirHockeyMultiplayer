using Unity.Netcode;
using UnityEngine;

public class Camera : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsHost)
        {
            gameObject.transform.SetPositionAndRotation(new Vector3(0, 6.5f, -6.8f), Quaternion.Euler(new Vector3(52f, 0, 0)));
        }
        else if (IsClient)
        {
            gameObject.transform.SetPositionAndRotation(new Vector3(0, 6.5f, 6.8f), Quaternion.Euler(new Vector3(52f, 180f, 0)));
        }
    }
}
