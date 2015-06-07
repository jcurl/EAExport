README

Jason Curl, 2015/June/07

==============================================================================
Building this Software
==============================================================================
This project uses packages from NuGET. It was built using Visual Studio 2013
Ultimate.

The following external packages are used:
* HtmlRenderer.Core.1.5.0.5
* HtmlRenderer.WinForms.1.5.0.6

When building the project for the first time, it will download and install the
NuGet packages for you. They are then placed in the folder:
* packages\HtmlRenderer.Core.1.5.0.5
* packages\HtmlRenderer.WinForms.1.5.0.6

The software will build and compile fine.

==============================================================================
Using the IDE
==============================================================================
When you open the form, the IDE will complain about not being able to load the
HTML Renderer control. This appears to be a bug in the packaging as it crashes
both on VS2012 and VS2013.

To fix this problem, copy these files:
  packages\HtmlRenderer.Core.1.5.0.5\lib\net40-client\HtmlRenderer.*
to
  packages\HtmlRenderer.WinForms.1.5.0.6\lib\net40-client
  
I don't know why this fails as all references are present.