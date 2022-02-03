using Adopte1Dev.BLL.Entities;
using Adpote1Dev.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adpote1Dev.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
        public bool IsConnected { get { return _session.GetString(nameof(User)) != null; } }

        public ClientBLL User
        {
            set
            {
                _session.SetString(nameof(User), JsonSerializer.Serialize(value));
            }
            get
            {
                return JsonSerializer.Deserialize<ClientBLL>(_session.Get(nameof(User)));
            }
        }

    }
}
