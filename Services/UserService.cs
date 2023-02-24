using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ticketing_System.Models;

public class UserService : IUserService
{

    private UserContext userContext;

    public UserService(UserContext _userContext)
    {
        userContext = _userContext;
    }

    public string Login(userSignUpDto user)
    {
        var ur = userContext.Users.FirstOrDefault(u => u.email.ToLower() == user.email.ToLower());

        if (ur == null) return "no user";
        else if (verifyPassword(user, ur))
        {
            return CreateToken(ur);
        }
        else
        {
            return "wrong password";
        }


        throw new NotImplementedException();
    }


    private string CreateToken(User ur)
    {

        User u =userContext.Users.Include(a=>a.rolesList).
          FirstOrDefault(a=>a.userId==ur.userId);

        Console.WriteLine(ur.email);   
        List<Claim> claimList=new List<Claim>();

        if(ur.rolesList==null||ur.rolesList.Count==0)return "please add role";

        foreach (var item in u.rolesList)
        {
            claimList.Add(new Claim("roles",item.name));
        }
        

        var secretKey = new SymmetricSecurityKey
                   (Encoding.UTF8.GetBytes("Thisismysecretkey"));
        var signinCredentials = new SigningCredentials
       (secretKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            "https://localhost:7154",
            "https://localhost:7154",
            claims: claimList,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signinCredentials
        );
        return new JwtSecurityTokenHandler().
        WriteToken(jwtSecurityToken);

    }



    public bool verifyPassword(userSignUpDto user, User ur)
    {
        return ur.password == user.password;
    }

    public string SignUp(userSignUpDto user)
    {

        if (UserExists(user.email))
        {
            return "user already exist";
        }
        else
        {
            User u = new User();

            u.email = user.email;
            u.password = user.password;
            u.name = user.name;
            u.rolesList = new List<Role>();

            userContext.Add(u);
            userContext.SaveChanges();
            return "done";
        }

    }


    public bool UserExists(string username)
    {
        if (userContext.Users.Any(u => u.email.ToLower() == username.ToLower()))
            return true;
        return false;
    }

    public User AddRole(int userId, int roleId)
    {

        var user = userContext.Users.FirstOrDefault(u => u.userId == userId);
        var role = userContext.Roles.FirstOrDefault(u => u.roleId == roleId);

        if (user.rolesList == null)
        {
            user.rolesList = new List<Role>();
        }
        user.rolesList.Add(role);



        userContext.Update<User>(user);
        userContext.SaveChanges();

        return userContext.Users.Include(s => s.rolesList).ToList()[0];

    }
}