using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        private static Random random = new Random();

        public static List<Models.Review> Reviews = new List<Models.Review>();

        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static Models.Review CreateReview(Rating rating)
        {
            return new Models.Review()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                Grade = random.Next(6),
                Text = LoremIpsum.Substring(random.Next(20, 100)),
                UserId = Guid.NewGuid(),
                RatingId = rating.Id,
                //Rating = rating,
                Status = (ReviewStatus)random.Next(2)
            };
        }

        public static Rating[] GetRatings()
        {
            var count = 100;
            var ratings = new List<Rating>(count);
            for (int i = 1; i <= count; i++)
            {
                var rating = CreateRating(Guid.NewGuid());
                ratings.Add(rating);
            }
            return ratings.ToArray();
        }

        public static Rating CreateRating(Guid id)
        {
            var rating = new Rating()
            {
                Id = id,
                CreateDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                ProductId = Guid.NewGuid(),
            };
            var reviewsCouunt = random.Next(1, 10);
            for (int k = 1; k <= reviewsCouunt; k++)
            {
                Reviews.Add(CreateReview(rating));
            }

            return rating;
        }

        public static Login[] GetLogins()
        {
            var results = new List<Login>();
            var login1 = new Login()
            {
                Id = 1,
                UserName = "admin",
                Password = "admin"
            };
            results.Add(login1);
            return results.ToArray();
        }
    }
}
