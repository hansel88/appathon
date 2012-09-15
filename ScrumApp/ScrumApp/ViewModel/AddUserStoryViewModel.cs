using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    class AddUserStoryViewModel
    {
        public void SaveUserStory(string title, string description, int priority)
        {
            var story = new Story();
            story.Title = title;
            story.Description = description;
            story.Priority = priority;
            story.Author = DataStructure.CurrentUser;
            story.CreatedDate = DateTime.Now;
            story.State = StoryStates.Unassigned;

            if (DataStructure.CurrentProject != null)
            {
                DataStructure.CurrentProject.StoryQueue.Add(story);
            }
        }
    }
}
