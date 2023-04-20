using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            ChangeButtonColor(hostButton);
        });

        serverButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            ChangeButtonColor(serverButton);
        });

        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            ChangeButtonColor(clientButton);
        });
    }

    private void ChangeButtonColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.green;
        cb.selectedColor = Color.green;
        button.colors = cb;
    }
}
