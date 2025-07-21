using NUnit.Framework;
using UnityEngine;
using System.Diagnostics;

public class TorchPerformanceTest
{
    [Test]
    public void Torch_LightUp_Performance()
    {
        var stopwatch = new Stopwatch();
        var torches = new Torch[10000];

        for (int i = 0; i < torches.Length; i++)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var torch = go.AddComponent<Torch>();
            torch.rend = go.GetComponent<Renderer>();
            if (torch.rend.sharedMaterial == null)
                torch.rend.sharedMaterial = new Material(Shader.Find("Standard"));
            torches[i] = torch;
        }

        stopwatch.Start();
        foreach (var torch in torches)
        {
            torch.LightUp();
        }
        stopwatch.Stop();

        UnityEngine.Debug.Log($"Lighting 10000 torches took {stopwatch.ElapsedMilliseconds}ms");

        Assert.Less(stopwatch.ElapsedMilliseconds, 200, "Performance: Lighting 10000 torches took too long");
    }
}