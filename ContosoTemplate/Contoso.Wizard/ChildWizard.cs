using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Wizard
{
    public class ChildWizard
        : IWizard
    {
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            // Replaces $rootprojectname$ with the name entered in the dialog box (hopefully)
            var firstProjectName = replacementsDictionary["$safeprojectname$"];
            var projectNameParts = firstProjectName.Split('.');
            var rootProjectName = String.Join(".", projectNameParts.Take(projectNameParts.Count() - 1));

            replacementsDictionary.Add("$rootprojectname$", rootProjectName);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {

        }       
    }
}
