# ContosoTemplate
A multi project visual studio template using Visual Studio 2017

In order to use this with Visual Studio 2015, there is a requirement to have the Visual Studio SDK installed, please see [Visual Studio 2015 SDK Install Instructions](https://msdn.microsoft.com/en-us/library/mt683786.aspx)

## Steps to Recreate a multi project template like this

1. Create a solution file that resmbles what you want the project template to look like.
1. Export each project by going up to Project -> Export Template...
1. Select the Project Template option.
1. Under "From which project would you like to create a template?" option select the project we are exporting.
1. Click Next<br />
![Export Template Wizard Step 1](https://github.com/jwendl/ContosoTemplate/raw/master/DocumentationImages/TemplateExportWizardStep1.png)
1. Configure template options and select Finish<br />
![Export Template Wizard Step 1](https://github.com/jwendl/ContosoTemplate/raw/master/DocumentationImages/TemplateExportWizardStep2.png)
1. Repeat these steps for each project under your solution file.
1. Open Visual Studio and create a new "Blank VSIX Project" project.
1. Once the VSIX project is created we are going to add a class library and a project template project as well.
1. Your solution file should look like the following screen shot.<br />
![Export Template Wizard Step 1](https://github.com/jwendl/ContosoTemplate/raw/master/DocumentationImages/SolutionFile.png)
1. Where **Contoso.Template** is the VSIX project, **Contoso.Web.Template** is the Project Template project and **Contoso.Wizard** is the class library project.
1. In the VSIX project (Contos.Template in our example), add a project reference to the other two projects.
1. Then open the source.extension.vsixmanifest file.
1. Select Assets and setup the other two project in a similar fashion to the screenshot below.<br />
![Export Template Wizard Step 1](https://github.com/jwendl/ContosoTemplate/raw/master/DocumentationImages/AssetsScreen.png)
1. In the project template project (ours is named Contoso.Web.Template) edit the MyTemplate.vstemplate file by adding the code below.
1. Create a folder called ProjectTemplates
1. Edit the Contoso.Web.Template.csproj by changing "<Compile" tags to "<Content" tags and the "<VSTemplate" xml fragment from the code example below.


## Code Sections from Above

### MyTemplate.vstemplate
```XML
  <TemplateContent>
    <ProjectCollection>
      <ProjectTemplateLink ProjectName="$safeprojectname$.Web">
        ProjectTemplates\Web\MyTemplate.vstemplate
      </ProjectTemplateLink>
      <ProjectTemplateLink ProjectName="$safeprojectname$.Business">
        ProjectTemplates\Business\MyTemplate.vstemplate
      </ProjectTemplateLink>
      <ProjectTemplateLink ProjectName="$safeprojectname$.Data">
        ProjectTemplates\DataAccess\MyTemplate.vstemplate
      </ProjectTemplateLink>
    </ProjectCollection>
  </TemplateContent>
  <WizardExtension>
    <Assembly>Contoso.Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b544984fa8653e07</Assembly>
    <FullClassName>Contoso.Wizard.InitialWizard</FullClassName>
  </WizardExtension>
```

### Contoso.Web.Template.csproj
```XML
  <ItemGroup>
    <Content Include="__TemplateIcon.ico" />
    <VSTemplate Include="MyTemplate.vstemplate" />
    <Content Include="ProjectTemplates\Business\Contoso.Business.csproj" />
    <Content Include="ProjectTemplates\Business\MyTemplate.vstemplate" />
    <Content Include="ProjectTemplates\Business\__TemplateIcon.ico" />
    <Content Include="ProjectTemplates\DataAccess\Contoso.Data.csproj" />
    <Content Include="ProjectTemplates\DataAccess\MyTemplate.vstemplate" />
    <Content Include="ProjectTemplates\DataAccess\__TemplateIcon.ico" />
    <Content Include="ProjectTemplates\Web\App_Start\BundleConfig.cs" />
    <Content Include="ProjectTemplates\Web\App_Start\FilterConfig.cs" />
    <Content Include="ProjectTemplates\Web\App_Start\RouteConfig.cs" />
    <Content Include="ProjectTemplates\Web\App_Start\UnityConfig.cs" />
    <Content Include="ProjectTemplates\Web\App_Start\UnityMvcActivator.cs" />
    <Content Include="ProjectTemplates\Web\Controllers\HomeController.cs" />
    <Content Include="ProjectTemplates\Web\Global.asax.cs">
      <DependentUpon>Global.asax</DependentUpon>
    </Content>
    <Content Include="ProjectTemplates\Web\Properties\AssemblyInfo.cs" />
    <Content Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
```