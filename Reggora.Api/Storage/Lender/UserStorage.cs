using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Users;
using Reggora.Api.Util;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class UserStorage : Storage<User, Api.Lender>
    {
        public UserStorage(Api.Lender api) : base(api)
        {
        }

        public string Create(User user)
        {
            string response = null;
            var result = new CreateUserRequest(user).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                user.Clean();

            }

            return response;
        }

        public List<User> All()
        {
            var result = new GetUsersRequest().Execute(Api.Client);
            var fetchedUsers = result.Data;
            List<User> users = new List<User>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedUsers.Count; i++)
                {
                    User tempUser = new User();
                    tempUser.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedUsers[i]));
                    users.Add(tempUser);
                }
            }
            return users;
        }

        public override User Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetUserRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new User();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public string Invite(User user)
        {
            string response = "";
            var result = new InviteUserRequest(user).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                user.Clean();
            }
            return response;
        }

        public override void Save(User user)
        {

        }


        public string Edit(User user)
        {
            string response = "";
            var result = new EditUserRequest(user).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                user.Clean();
            }
            return response;
        }

        public string Delete(string id)
        {
            string response = null;
            var result = new DeleteUserRequest(id).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }
    }
}
