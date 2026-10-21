namespace Mathtone.Sdk.NeuralNetworks.Tests;

public class NeuralNetworkTests {
	[Fact]
	public void Output_WhenNetworkHasNoLayers_IsEmpty() {
		var network = new NeuralNetwork();

		Assert.Empty(network.Output);
	}
}