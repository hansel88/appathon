﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Controller;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    public class AddProjectViewModel : ViewModelBase
    {
        public AddProjectViewModel(ProjectController ctrl = null)
        { 
            this.ctrl = (ctrl != null ? ctrl : new ProjectController());
        }

        ProjectController ctrl;

        public List<User> Users
        {
            get
            {
                return DataStructure.Users;
            }
        }

        /// <summary>
        /// Attempts to save a project in the internal structure.
        /// </summary>
        /// <param name="project">The barebone Project object needed.</param>
        /// <returns>The complete project</returns>
        public Project SaveProject(Project project)
        {
            return ctrl.SaveProject(project);
        }


    }
}
