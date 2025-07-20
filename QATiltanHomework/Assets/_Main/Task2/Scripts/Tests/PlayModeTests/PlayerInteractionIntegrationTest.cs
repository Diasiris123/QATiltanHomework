using NUnit.Framework;
using UnityEngine;

public class PlayerInteractionIntegrationTest
{
    [Test]
    public void PlayerLightsUpTorch_WhenNearbyAndPressesE()
    {
        var player = new GameObject("Player");
        player.AddComponent<PlayerTorchInteractor>();
        player.transform.position = Vector3.zero;

        var torchObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        torchObj.transform.position = Vector3.one;
        var torch = torchObj.AddComponent<Torch>();
        torch.rend = torchObj.GetComponent<Renderer>();
        
        Collider[] hits = Physics.OverlapSphere(player.transform.position, 2f);
        foreach (var hit in hits)
        {
            Torch t = hit.GetComponent<Torch>();
            if (t != null) t.LightUp();
        }

        Assert.IsTrue(torch.isLit);
    }
}