using System;
using System.Collections.Generic;
using System.Text;

namespace buddyV2.helpers
{
    public interface IFirebaseAuthenticator
    {
        void LoginWithEmailPassword(string email, string password);
    }
}
