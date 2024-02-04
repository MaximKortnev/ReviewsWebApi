namespace Review.Domain.Services
{
    public interface IReviewService
    {
        /// <summary>
        /// Добавление нового отзыва
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// /// <param name="review">Отзыв</param>
        /// <returns></returns>
        Task AddAsync(Guid productId, Models.Review review);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        Task<List<Models.Review>> GetAllByProductIdAsync(Guid productId);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<Models.Review?> TryGetByIdAsync(Guid id);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task TryToDeleteAsync(Guid id);
    }
}
