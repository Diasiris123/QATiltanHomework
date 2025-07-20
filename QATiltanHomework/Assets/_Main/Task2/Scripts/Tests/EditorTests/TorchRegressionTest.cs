using NUnit.Framework;
using UnityEngine;

public class TorchRegressionTest
{
    [Test]
    public void LightUp_CallsUpdateVisual_ColorBecomesYellow()
    {
        var go = new GameObject();
        var torch = go.AddComponent<Torch>();
        var rend = go.AddComponent<MeshRenderer>();
        rend.sharedMaterial = new Material(Shader.Find("Standard"));
        torch.rend = rend;

        torch.LightUp();

        Assert.AreEqual(Color.yellow, rend.sharedMaterial.color);
    }
}