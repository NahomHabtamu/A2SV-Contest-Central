﻿using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class A2SVGroupRepository : GenericRepository<GroupEntity>, IA2SVGroupRepository
{
    protected A2SVGroupRepository(AppDBContext dbContext) : base(dbContext)
    {
    }
}