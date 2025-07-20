using NUnit.Framework;
using UnityEngine;

public class TorchTests
{
    [Test]
    public void LightUp_SetsIsLitToTrue()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var torch = go.AddComponent<Torch>();
        torch.rend = go.AddComponent<MeshRenderer>();

        torch.LightUp();
        Assert.IsTrue(torch.isLit);
    }

    [Test]
    public void UpdateVisual_ChangesColorToYellow()
    {
        var go = new GameObject();
        var torch = go.AddComponent<Torch>();
        var rend = go.AddComponent<MeshRenderer>();
        rend.sharedMaterial = new Material(Shader.Find("Standard"));
        torch.rend = rend;

        torch.isLit = true;
        torch.UpdateVisual();

        Assert.AreEqual(Color.yellow, rend.sharedMaterial.color);
    }
}