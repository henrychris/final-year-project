using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLPrediction.DataModels;

namespace MLPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<ProductDataModel, ProductDataPrediction> _predictionEnginePool;

        public PredictController(PredictionEnginePool<ProductDataModel, ProductDataPrediction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] ProductDataModel input)
        {
            var isRecommended = false;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ProductDataPrediction prediction = _predictionEnginePool.Predict(modelName: "ProductPredictionModel", example: input);

            if (Math.Round(prediction.Score, 1) > 3.5)
            {
                isRecommended = true;
            }

            return Ok(isRecommended);
        }
    }
}
