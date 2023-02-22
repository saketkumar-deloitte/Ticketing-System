using Ticketing_System.Models;

public interface IUserService{


    String SignUp(userSignUpDto user);

    String Login(userSignUpDto user);

    User AddRole(int userId,int roleId);
}
