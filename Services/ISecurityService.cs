using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurityService" in both code and config file together.
    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        IList<User> GetAllUsers();

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        void RemoveUser(User user);
    }
}
