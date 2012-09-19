using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Utilities;

namespace SharedResources.Controller
{
    public class ProjectController
    {

        /// <summary>
        /// Attempts to save a project. This method fills out automatically generated fields.
        /// </summary>
        /// <param name="project">The basic Project-object to fill out and register</param>
        /// <returns>Null if failure, completed object if success.</returns>
        /// <exception cref="ArgumentNullException">No project was given</exception>
        /// <exception cref="ArgumentException">Project was</exception>
        public Project SaveProject(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("No project was given to register");

            if (DataStructure.Projects.Where(p => p.Name == project.Name).First() != null)
                throw new ArgumentException("A project with the same name was found.");

            // TODO: Add owner?
            project.Sprints = new List<Sprint>();
            project.StoryQueue = new List<Story>();

            DataStructure.Projects.Add(project);

            return project;
        }

        /// <summary>
        /// Edits any properties of a given project
        /// </summary>
        /// <param name="oldProject">The Project to be updated</param>
        /// <param name="newProject">The object containing all new properties</param>
        /// <returns>The updated project</returns>
        /// <exception cref="ArgumentNullException">When one or both arguments are null</exception>
        /// <exception cref="KeyNotFoundException">When a project was not found</exception>
        public Project EditProject(Project oldProject, Project newProject)
        {
            if (oldProject == null || newProject == null)
                throw new ArgumentNullException("Both project properties must be set");

            if (DataStructure.Projects.Find(p => p == oldProject) == null)
                throw new KeyNotFoundException("Project given was not found");

            var tmpProject = new Project();
            tmpProject.Description = newProject.Description ?? oldProject.Description;
            
            tmpProject.Name = newProject.Name ?? oldProject.Name;
            tmpProject.Sprints = newProject.Sprints ?? oldProject.Sprints;
            tmpProject.StoryQueue = newProject.StoryQueue ?? oldProject.StoryQueue;

            tmpProject.EndDate =  (newProject.EndDate != new DateTime() ? newProject.EndDate : oldProject.EndDate);
            tmpProject.StartDate =  (newProject.StartDate != new DateTime() ? newProject.StartDate : oldProject.StartDate);

            DataStructure.Projects.Remove(oldProject);
            DataStructure.Projects.Add(tmpProject);

            return tmpProject;
        }

        /// <summary>
        /// Attempts to remove a project from the database.
        /// </summary>
        /// <param name="projectToRemove">The project to remove</param>
        /// <returns>The project that was removed</returns>
        /// <exception cref="ArgumentNullException">No project was provided</exception>
        /// <exception cref="ArgumentException">The project was not found</exception>
        public Project RemoveProject(Project projectToRemove)
        {
            if (projectToRemove == null)
                throw new ArgumentNullException("No project was given to remove");

            if (DataStructure.Projects.Remove(projectToRemove))
            {
                return projectToRemove;
            }
            throw new ArgumentException("Project was not found in database");
        }
    }
}
