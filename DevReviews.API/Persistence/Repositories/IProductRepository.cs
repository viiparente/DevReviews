using DevReviews.API.Entities;

namespace DevReviews.API.Persistence.Repositories
{
    public interface IProductRepository
    {
        #region Product
        Task AddAsync(Product product);
        Task<Product> GetDetailsByIdAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
        #endregion

        #region ProductReview
        Task<ProductReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ProductReview productReview);
        #endregion
    }
}