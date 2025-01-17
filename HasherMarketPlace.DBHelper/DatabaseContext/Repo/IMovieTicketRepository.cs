﻿namespace HasherMarketPlace.DBHelper.DatabaseContext.Repo
{
    public interface IMovieTicketRepository<TEntity> : IDisposable
    {
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);

        Task<TEntity> AddReturnIdAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
