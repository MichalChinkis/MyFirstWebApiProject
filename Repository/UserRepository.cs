using entities;
using System.Text.Json;

namespace Repository;

public class UserRepository : IUserRepository
{
  
    private readonly string filePath = "Files//users.json";
    public async Task<UserClass> getUserByUserNameAndPassword(string UserName, string Password)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile =await reader.ReadLineAsync()) != null)
            {
                UserClass user = JsonSerializer.Deserialize<UserClass>(currentUserInFile);
                if (user.UserName == UserName && user.Password == Password)
                    return user;
            }
            return null;
        }

    }


    //לא שונה עקב אי-הצלחתה של המורה
    public UserClass addUser(UserClass user)
    {
        int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        user.Id = numberOfUsers + 1;
        string userJson = JsonSerializer.Serialize(user);
        System.IO.File.AppendAllText("Files//users.json", userJson + Environment.NewLine);
        return user;
    }

    public async Task<UserClass> updateUser(int id, UserClass userToUpdate)
    {
        userToUpdate.Id = id;
        string textToReplace = string.Empty;
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {

                UserClass user = JsonSerializer.Deserialize<UserClass>(currentUserInFile);
                if (user.Id == id)
                    textToReplace = currentUserInFile;
                
            }
        }

        if (textToReplace != string.Empty)
        {
            string text = System.IO.File.ReadAllText(filePath);
            text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            System.IO.File.WriteAllText(filePath, text);
        } 
      return userToUpdate;
    }
}