using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourseAPI;
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
         var ur=userContext.Users.FirstOrDefault(u => u.email.ToLower() == user.email.ToLower());

          if(ur==null)return "no user";
         else if(verifyPassword(user,ur)){
            return CreateToken(user);
         }else{
            return "wrong password";
         }


        throw new NotImplementedException();
    }


      private string CreateToken(userSignUpDto user){

         var secretKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("Thisismysecretkey"));
                    var signinCredentials = new SigningCredentials
                   (secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        "https://localhost:7154",  
                        "https://localhost:7154", 
                        claims:new List<Claim>(){new Claim("roles","admin")},
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return new JwtSecurityTokenHandler().
                    WriteToken(jwtSecurityToken);
       
    }



    public bool verifyPassword(userSignUpDto user, User ur)
    {
        return ur.password==user.password;
    }

    public string SignUp(userSignUpDto user)
    {

        if (UserExists(user.email))
        {
            return "user already exist";
        }
        else
        {
            User u = new User()
            {
                email = user.email,
                password = user.password,
                name = user.name
            };
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
}