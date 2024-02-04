using ReviewsWebApplication.Models;
using Review.Domain.Models;

namespace ReviewsWebApplication
{
    public static class MappingsHelper
    {
        public static List<ReviewApi> ToReviewsApiModels(this List<Review.Domain.Models.Review> reviews) 
        {
            if (reviews == null)
                return null;

            return reviews.Select(ToReviewApiModel).ToList();
        }

        public static ReviewApi ToReviewApiModel(this Review.Domain.Models.Review review)
        {
            if (review == null) 
                return null;
            return new ReviewApi() {
                CreateDate = review.CreateDate,
                Id = review.Id,
                Text = review.Text,
                Grade = review.Grade,
                UserId = review.UserId
            };
        }


        public static Review.Domain.Models.Review ToReview(this AddReviewApi addReviewApi)
        {
            return new Review.Domain.Models.Review
            {
                CreateDate = DateTime.UtcNow,
                Grade = addReviewApi.Grade,
                Status = ReviewStatus.Actual,
                Text = addReviewApi.Text,
                UserId = addReviewApi.UserId
            };
        }
    }
}
