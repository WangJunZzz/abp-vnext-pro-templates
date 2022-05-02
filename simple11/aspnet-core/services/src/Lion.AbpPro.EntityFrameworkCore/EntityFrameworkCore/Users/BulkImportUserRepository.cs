﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lion.AbpPro.Users;
using Microsoft.EntityFrameworkCore.Storage;
using MySqlConnector;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;

namespace Lion.AbpPro.EntityFrameworkCore;

public class BulkImportUserRepository:IBulkImportUserRepository
{
    private readonly IDbContextProvider<AbpProDbContext> _contextProvider;

    public BulkImportUserRepository(IDbContextProvider<AbpProDbContext> contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public async Task BulkInsertAsync(List<IdentityUser> identityUsers)
    {
        // TODO 这个地方创建人和创建时间需要手动赋值。
        
        // 完美契合abp，并且能够触发领域事件和分布式事件
        var context = await _contextProvider.GetDbContextAsync();
        await context.BulkInsertAsync(identityUsers, context.Database.CurrentTransaction.GetDbTransaction() as MySqlTransaction);
    }
}