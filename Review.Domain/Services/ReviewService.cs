using Microsoft.EntityFrameworkCore;

namespace Review.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AddAsync(Guid productId, Models.Review review)
        {
            var rating = await databaseContext.Ratings.Include(x => x.Reviews).FirstOrDefaultAsync(x => x.ProductId == productId);

            if(rating == null)
            {
                rating = new Models.Rating
                {
                    ProductId = productId,
                    CreateDate = DateTime.UtcNow,
                    Reviews = new List<Models.Review>()
                };
                await databaseContext.Ratings.AddAsync(rating);
            }


            rating.Reviews.Add(review);

            await databaseContext.AddAsync(review);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Models.Review>?> GetAllByProductIdAsync(Guid productId)
        {
            var rating = await databaseContext.Ratings.Include(x => x.Reviews).FirstOrDefaultAsync(x => x.ProductId == productId);
            return rating?.Reviews.Where(x => x.Status == ReviewStatus.Actual).ToList();
        }

        public async Task<Models.Review?> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Reviews.FirstOrDefaultAsync(x => x.Id == id && x.Status == ReviewStatus.Actual);
        }

        public async Task TryToDeleteAsync(Guid id)
        {
            var review = await TryGetByIdAsync(id);

            if (review == null)
            {
                throw new NullReferenceException($"Отзыва с id={id} не существует");
            }

            review.Status = ReviewStatus.Deleted;
            await databaseContext.SaveChangesAsync();
        }
    }
}
