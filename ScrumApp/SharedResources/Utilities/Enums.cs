using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Utilities
{
    public enum StoryStates
    {
        Unassigned, Open, InAnalysis, InProgress, Testing, Closed
    }

    public enum PermissionLevel
    { 
        Open = 1, UserOnly = 2, AdminOnly = 3
    }
}
