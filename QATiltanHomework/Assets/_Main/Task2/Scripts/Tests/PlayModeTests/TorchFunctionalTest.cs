using NUnit.Framework;
using UnityEngine;

public class TorchFunctionalTest
{
    [Test]
    public void PlayerLightsAllTorches_TorchesStayLit()
    {
        var player = new GameObject("Player");
        player.transform.position = Vector3.zero;

        for (int i = 0; i < 3; i++)
        {
            var torchObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            torchObj.transform.position = new Vector3(i * 2, 0, 0);
            var torch = torchObj.AddComponent<Torch>();
            torch.rend = torchObj.GetComponent<Renderer>();

            torch.LightUp();
            Assert.IsTrue(torch.isLit);
        }
        
        player.transform.position = new Vector3(100, 0, 0);

        var allTorches = GameObject.FindObjectsOfType<Torch>();
        foreach (var torch in allTorches)
        {
            Assert.IsTrue(torch.isLit);
        }
    }
}