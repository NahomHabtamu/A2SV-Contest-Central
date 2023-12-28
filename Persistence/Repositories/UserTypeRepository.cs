using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UserTypeRepository : GenericRepository<UserTypeEntity>, IUserTypeRepository
{
    private readonly AppDBContext _dbContext;
    public UserTypeRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}