using System;

namespace Review.Domain.Models
{
    public class Review
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Оценка (количество звезд)
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        public Guid RatingId { get; set; }

        public Rating Rating { get; set; }

        public ReviewStatus Status { get; set; }
    }
}
