using NUnit.Framework;
using UnityEngine;

public class TorchSmokeTest
{
    [Test]
    public void Scene_ContainsPlayerAndTorches_NoErrors()
    {
        var player = new GameObject("Player");
        player.tag = "Player"; 
        
        var torchGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var torch = torchGO.AddComponent<Torch>();
        torch.rend = torchGO.GetComponent<Renderer>();
        
        var foundPlayer = GameObject.FindWithTag("Player");
        Assert.IsNotNull(foundPlayer, "Player is missing");
        
        var torches = GameObject.FindObjectsOfType<Torch>();
        Assert.IsTrue(torches.Length >= 1, "No torches found");
        
        foreach (var t in torches)
        {
            Assert.IsNotNull(t.rend, $"Torch missing renderer: {t.name}");
        }
    }
}