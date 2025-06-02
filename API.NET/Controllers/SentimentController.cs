using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SentimentController : ControllerBase
{
    private readonly SentimentModel _sentimentModel = new();

    [HttpPost]
    public IActionResult Analyze([FromBody] SentimentData input)
    {
        var prediction = _sentimentModel.Predict(input.Text);
        return Ok(new
        {
            Sentiment = prediction.Prediction ? "Positive" : "Negative",
            Probability = prediction.Probability
        });
    }
}
