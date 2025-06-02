using Xunit;

public class SentimentModelTests
{
    [Fact]
    public void Deve_Retornar_Positivo_Para_Texto_Positivo()
    {
        var model = new SentimentModel();
        var resultado = model.Predict("Eu gostei muito do produto!");

        Assert.True(resultado.Prediction);
    }

    [Fact]
    public void Deve_Retornar_Negativo_Para_Texto_Negativo()
    {
        var model = new SentimentModel();
        var resultado = model.Predict("Péssima experiência, não recomendo.");

        Assert.False(resultado.Prediction);
    }
}
