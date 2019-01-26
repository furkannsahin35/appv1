using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using buddyV2.helpers;
using Firebase.Auth;
using Foundation;
using UIKit;

namespace buddyV2.iOS
{
   public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async void LoginWithEmailPassword(string email, string password)
        {
            var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
        }
    }
}