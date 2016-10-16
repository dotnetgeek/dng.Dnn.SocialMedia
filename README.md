# dng.Dnn.SocialMedia

Project Description
-------------------

This SkinObject add nessary MetaTags for Facebook and Twitter. It use the PageTitle, PageDescription and the IconLargeFile that can be configured for every tab.
It is build for [DNN®](http://www.dnnsoftware.com/) ( formerly DotNetNuke® ).

How to use
----------

Right now there is no package to install this SkinObject. However it is really simple to use it. Copy the _dng.Dnn.SocialMedia.dll_ to your _bin_ folder

Add the following _Register_ to your skin:

    <%@ Register TagPrefix="dng" Namespace="dng.Dnn.SocialMedia.Skins" Assembly="dng.Dnn.SocialMedia" %>

After that you can use the following custom tag inside your skin:

    <dng:MetaTags runat="server" Sitename="your page name" TwitterCard="summary_large_image" />


To Do's:
--------

* Build Scripts
* Create Install-Package
