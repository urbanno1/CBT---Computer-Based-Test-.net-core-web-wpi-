using System;
using System.Collections.Generic;
using System.Text;

namespace CBT.Service.Helpers
{
    public static class RepsonseMessages
    {
        private static string messageResponse = null;

        public static string PrintResponseMessage(string messageIdentifier)
        {
            switch (messageIdentifier)
            {
                // Auth Controller
                case "AuthRegister.Success":
                    messageResponse = "Registration was successful, please excercise patience while the admin comes to your system to log you in.";
                    break;
                case "AuthRegister.Error":
                    messageResponse = "Registeration was not successful!";
                    break;

                case "AuthLogin.Error":
                    messageResponse = "Username or Password Invalid";
                    break;
                case "AuthGetToggleSetting.Error":
                    messageResponse = "Error processing your request";
                    break;
                case "CandidateGetInstructions.Error":
                    messageResponse = "Instructions are empty";
                    break;
                case "CandidateGetQuestions.Error":
                    messageResponse = "Questions are empty";
                    break;
                case "CandidateGetTimeObject.Error":
                    messageResponse = "Time Object not found";
                    break;
                case "CandidateGetUserClaims.Error":
                    messageResponse = "User not found";
                    break;

                default:
                    messageResponse = "";
                    break;
            }
            return messageResponse;
        }
    }
}
