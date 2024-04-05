using ASP_Demo_Archi_DAL.Models;
using Newtonsoft.Json;

namespace ASP_Demo_Archi.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor context)
        {
            _session = context.HttpContext.Session;
        }

        public User? CurrentUser
        {
            get { 
                
                if(string.IsNullOrEmpty(_session.GetString("user"))) 
                    return null; 

                return JsonConvert.DeserializeObject<User>(_session.GetString("user")); 
            }
            set { 
                _session.SetString("user", JsonConvert.SerializeObject(value)); 
            }
        }

        public void Logout()
        {
            _session.Clear();
        }

    }
}
