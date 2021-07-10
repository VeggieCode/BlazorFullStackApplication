using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyCrud.Client.Helpers
{
    public class AppState
    {        
        public event Func<Task> OnUpdatePendingSyncs;
        public async Task NotifyUpdatePendingSyncs() => await OnUpdatePendingSyncs?.Invoke();
    }
}
