using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LAB1.Pages
{
    public class Zadanie2Model : PageModel
    {
         public class UserModel
        {
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
        }
    
        public UserModel UserData { get; set; } = new UserModel();
        public bool ShowData { get; set; } = false;

        public void OnPost(string name, string email, string message)
        {
            // Przypisujemy dane użytkownika do obiektu modelu
            UserData.Name = name;
            UserData.Email = email;
            UserData.Message = message;

            // Ustawiamy flagę, żeby dane były widoczne w widoku po przesłaniu
            ShowData = true;

            // VIEWDATA
            // ViewData["Name"] = name;
            // ViewData["Email"] = email;
            // ViewData["Message"] = message;
        }

        //Sessions

        // public void OnPostSession(string name, string email, string message)
        // {
        //     // Ustawiamy wartości w sesji
        //     HttpContext.Session.SetString("Name", name);
        //     HttpContext.Session.SetString("Email", email);
        //     HttpContext.Session.SetString("Message", message);
        // }

        // // Metoda do pobierania danych z sesji
        // public void LoadDataFromSession()
        // {
        //     ViewData["Name"] = HttpContext.Session.GetString("Name");
        //     ViewData["Email"] = HttpContext.Session.GetString("Email");
        //     ViewData["Message"] = HttpContext.Session.GetString("Message");
        // }

    }

   
}