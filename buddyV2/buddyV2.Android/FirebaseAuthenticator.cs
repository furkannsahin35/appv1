using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using buddyV2.helpers;
using Firebase.Auth;

namespace buddyV2.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async void LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.
                            SignInWithEmailAndPasswordAsync(email, password);
            //var token = await user.User.GetIdTokenAsync(false);
            //return token.Token;
        }
    }
}