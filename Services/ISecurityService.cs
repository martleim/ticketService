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
        IList<AspNetUser> GetAllUsers();

        [OperationContract]
        AspNetUser GetUserByEmail(string email);

        [OperationContract]
        void AddUser(AspNetUser user);

        [OperationContract]
        void UpdateUser(AspNetUser user);

        [OperationContract]
        void RemoveUser(AspNetUser user);

        [OperationContract]
        AspNetUser FindUser(string userName, string password);

        [OperationContract]
        AspNetUser GetByUserName(string username);

    }
}
