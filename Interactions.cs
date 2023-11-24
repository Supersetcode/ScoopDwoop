using UnityEngine;
using UnityEngine.Networking;

public class InteractionManager : NetworkBehaviour
{
    [SerializeField]
    private InputField interactionInput;

    
    public void SendInteraction()
    {
        
        if (!string.IsNullOrEmpty(interactionInput.text))
        {
            
            string interactionMessage = interactionInput.text;

            
            CmdSendInteraction(interactionMessage);
        }
    }

   
    [Command]
    private void CmdSendInteraction(string message)
    {
        RpcReceiveInteraction(message);
    }

    // RPC function to receive the interaction message and display it on both clients
    [ClientRpc]
    private void RpcReceiveInteraction(string message)
    {
        // Display the received interaction message on both clients
        Debug.Log("Received Interaction: " + message);
    }
}
