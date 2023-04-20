using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject mainCamera;
    private Transform mainCameraTransform;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        mainCameraTransform = Instantiate(mainCamera).transform;
        mainCameraTransform.GetComponent<NetworkObject>().Spawn();
    }
}
