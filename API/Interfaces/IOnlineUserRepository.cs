using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IOnlineUserRepository
    {
        List<string> GetOnlineUsers();
        List<int> GetOnlineUserIds();
        bool IsOnline(string username);
        void Online(OnlineUser user);
        void Offline(OnlineUser user);
    }
}