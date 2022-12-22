using Adapter.SQLServer.Repositories;
using Adapter.SQLServer;
using Core.Models;

namespace Adapter.SQLServer.Tests;

public class CategoryStoreShould
{
    [Fact]
    public async Task AddCategoryAsync()
    {
        var context = new AppDbContextFactory().CreateDbContext(new string[] {} );
        var repository = new CategoryRepository(context);

        var category = new Category();
        category.Name = "Viande";

        var result = await repository.CreateAsync(category);

        Assert.True(result);

    }
}