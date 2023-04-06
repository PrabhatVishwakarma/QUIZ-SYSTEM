
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T _object);
    public Task UpdateAsync(T _object);
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int Id);
    public Task DeleteAsync(int id);
    public Task<T> GetByIdAsync(int quizId, string userId);
   
}

