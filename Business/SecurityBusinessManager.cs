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

        public void AddUser(params User[] users)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(params User[] users)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(params User[] users)
        {
            throw new NotImplementedException();
        }
    }
}