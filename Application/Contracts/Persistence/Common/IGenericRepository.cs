﻿using MediatR;

namespace Application.Contracts.Persistence.Common;

public interface IGenericRepository<T> where T : class
{
    //get all
    public Task<IReadOnlyList<T>> GetAllAsync();

    //get by id
    public Task<T?> GetByIdAsync(Guid id);

    //create new
    public Task<T> CreateAsync(T entity);

    //create new entity by list
    public Task<Unit> CreateListAsync(IReadOnlyList<T> entities);
    //update 
    public Task<Unit> UpdateAsync(Guid id, T entity);

    
    //delete 
    public Task<Unit> DeleteAsync(Guid id);
    
    // check if exists
    public Task<bool> Exists(Guid id);

    // get paginated data based on page and page_size
    public Task<IReadOnlyList<T>> GetPagedEntitiesAsync(int skip, int take);

    // get total count of any entity
    public Task<int> GetTotalEntitiesCount();
}