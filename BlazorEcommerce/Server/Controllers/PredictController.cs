using BlazorEcommerce.Server.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace BlazorEcommerce.Server.Controllers
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
        public ActionResult<bool> GetProductRecommendation(ProductDataModel input)
        {
            var isRecommended = false;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // it is expected behaviour for the model to only predict correctly for the users it has data on.
            var prediction = _predictionEnginePool.Predict(modelName: "ProductPredictionModel", example: input);

            if (Math.Round(prediction.Score, 1) > 3.5)
            {
                isRecommended = true;
            }

            return Ok(isRecommended);
        }
    }
}
