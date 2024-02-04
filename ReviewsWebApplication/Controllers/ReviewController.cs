using Microsoft.AspNetCore.Mvc;
using Review.Domain.Services;
using ReviewsWebApplication.Models;

namespace ReviewsWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReviewController : ControllerBase
    {

        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            this.reviewService = reviewService;
        }

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByProductId")]
        public async Task<ActionResult<List<Review.Domain.Models.Review>>> GetByProductIdAsync(Guid productId)
        {
            try
            {
                var result = await reviewService.GetAllByProductIdAsync(productId) ?? new List<Review.Domain.Models.Review>();
                return Ok(result.ToReviewsApiModels());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<ActionResult<ReviewApi>> GetByIdAsync(Guid reviewId)
        {
            try
            {
                var result = await reviewService.TryGetByIdAsync(reviewId);
                return Ok(result.ToReviewApiModel());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Добавление отзыва
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(AddReviewApi addReviewApi)
        {
            try
            {
                await reviewService.AddAsync(addReviewApi.ProductId, addReviewApi.ToReview());
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Удаление отзыва по id
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await reviewService.TryToDeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

       
    }
}