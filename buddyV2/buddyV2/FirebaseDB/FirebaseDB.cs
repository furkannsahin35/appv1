using buddyV2.User;
using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyV2.FirebaseDB
{
    class FirebaseDB
    {
        FirebaseClient fbClient;

        public FirebaseDB()
        {
            fbClient = new FirebaseClient("https://buddyv2.firebaseio.com/");

        }

        public async Task sendUserCredentials(userCredentials userCredentials)
        {
            await fbClient.Child("userCredentials").PostAsync<userCredentials>(userCredentials);
        }

        public async Task<IEnumerable<userCredentials>> getUsers()
        {
            var getUsers = (await fbClient
                      .Child("userCredentials")
                      .OnceAsync<userCredentials>())
                      .Select((item) =>

                      new userCredentials
                      {
                          userName = item.Object.userName,
                          password = item.Object.password,
                          mail = item.Object.mail
                      }

                             ).ToList();

            return getUsers;
        }
    }
}
