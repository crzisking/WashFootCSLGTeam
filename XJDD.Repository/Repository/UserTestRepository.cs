using Microsoft.Extensions.DependencyInjection;
using XJDD.Repository.Entity;
using XJDD.Repository.IRepository;

namespace XJDD.Repository.Repository;

public class UserTestRepository(IServiceProvider serviceProvider) : IUserTestRepository
{
    private Repository<UserTest> _repository = serviceProvider.GetRequiredService<Repository<UserTest>>();

}