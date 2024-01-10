﻿using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UserTypeRepository : GenericRepository<UserTypeEntity>, IUserTypeRepository
{
    private readonly AppDBContext _dbContext;
    public UserTypeRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> GetUserTypeIdByUserTypeName(string user_type_name)
    {
        var role = await _dbContext.UserTypeEntities
                .Where(type => type.Name == user_type_name)
                .FirstOrDefaultAsync();

        if (role != null)
        {
            return role.Id;
        }
        return Guid.Empty;
    }
}