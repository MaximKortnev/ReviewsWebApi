namespace Review.Domain.Models
{
    /// <summary>
    /// Рейтинг
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Id рейтинга
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// отзывы
        /// </summary>
        public List<Review> Reviews { get; set; }

        public Rating()
        {
            Reviews = new List<Review>();
        }
    }
}
