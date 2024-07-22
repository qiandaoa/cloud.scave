using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;


namespace Admin2024.Domain.DomainServices;

public class UserDomainService : IUserDomainService
{
    private readonly IRepository<User> _repo;
    public UserDomainService(IRepository<User> repo)
    {
        _repo = repo;
    }
    public User? GetByUsername(string username)
    {
        var entity = _repo.Table.FirstOrDefault(e => e.Username == username);

        return entity;
    }

    public User? GetUserById(Guid id)
    {
        var entity = _repo.Table.FirstOrDefault(e => e.Id == id);
        return entity;
    }

    public async Task Register(User user)
    {
        var salt = PasswordHelper.GenerateSalt();
        var hashPassword = PasswordHelper.HashPassword(user.Password,salt);
        // 将新注册的账号信息添加到数据库中
        user.Password = hashPassword;
        user.Salt = salt;
        user.IsActived = true;
        
        await _repo.AddAsync(user); 

        // 由于id为主键自动生成，创建人和最后修改人在注册的第一时间无法获取到id，
        // 所以在注册时添加到数据库这一步后马上又对数据进行修改，将创建人和最后修改人修改为账号id
        user.CreateBy = user.Id;
        user.UpdateBy = user.Id;
        await _repo.UpdateAsync(user);  
    }
    public async Task ModifyPassword(User user)
    {
        await _repo.UpdateAsync(user);
    }
}