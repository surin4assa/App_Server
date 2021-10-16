using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalR
{
	[Authorize]
	public class PresenceHub : Hub
	{
		private readonly PresenceTracker _tracker;

		public PresenceHub(PresenceTracker tracker)
		{
			_tracker = tracker;
		}

		public override async Task OnConnectedAsync()
		{
			var caller = Context.User.GetUsername();
			var isOnline = await _tracker.UserConnected(caller, Context.ConnectionId);

			if (isOnline) // if user is online, notify other user
				await Clients.Others.SendAsync("UserIsOnline", caller);

			var currentUsers = await _tracker.GetOnlineUsers();
			await Clients.Caller.SendAsync("GetOnlineUsers", currentUsers);
		
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			var caller = Context.User.GetUsername();
			var isOffline = await _tracker.UserDisconnected(caller, Context.ConnectionId);
			if (isOffline) // if user is offline, notify other user
				await Clients.Others.SendAsync("UserIsOffline", caller);

			await base.OnDisconnectedAsync(exception);
		}
	}
}
