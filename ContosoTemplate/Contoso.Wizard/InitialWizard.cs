using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace Contoso.Wizard
{
    public class InitialWizard
        : IWizard
    {
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var inputForm = new InitialDialog();
            inputForm.ShowDialog();

            if (inputForm.SelectedCulture == null)
            {
                return;
            }

            replacementsDictionary.Add("$iniSelectedCulture$", inputForm.SelectedCulture);

            // Replaces $rootprojectname$ with the name entered in the dialog box (hopefully)
            replacementsDictionary.Add("$rootprojectname$", replacementsDictionary["$safeprojectname$"]);
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
