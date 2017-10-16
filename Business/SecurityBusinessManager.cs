using Tickets.Model;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;
using Tickets.DataAccess.PartialRepositories;

namespace Tickets.Business
{
    public class SecurityBusinessManager : BaseManager, ISecurityManager
    {

        private readonly EventRepository _eventRepository;


        public SecurityBusinessManager()
        {
            _eventRepository = new EventRepository();

        }

        public SecurityBusinessManager(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }

        public IList<AspNetUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public AspNetUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }
    }
}