# Vev + Optimizely integration
Create engaging and beatiful designs in [Vev](https://vev.design) and publish easily to your Optimizely CMS or Customized Commerce sites.

All content is pushed to your Optimizely CMS site and hosted there. This means all the content is delivered from your own domain and helps better your SEO ranking and no need to change your content security polices.

[*Video showing the publishing process in action*]

## Features
### Publish a Vev page as a page in Optimizely CMS
The content and design you create in Vev can be published directly as a page in Optimizely CMS. New pages are created under a predetermined "container" page in your CMS, and can then be moved in your page structure as you see fit.

### Publish a Vev page as a block in Optimizely CMS
You are not limited to creating full pages, use the creative freedom in Vev 

### Works with multiple languages
Create translated versions of your design in the same Vev project to publish as multi language versions of the same page in Optimizely CMS.

## Requirements
 * Optimzely CMS version 12.2 or newer (standalone or part of Customized Commerce)
 * A Vev Enterprise account with Optimizely hosting feature
 * One or more hosting destinations in Vev and configuration settings that correspond.

## Installation
The installation is done through a Nuget Package and custom page and block types to control rendering.
### Nuget 
Install the Nuget Package into your project:
```
install-package Vev.Optimizely.CMS
```
### Project Files
When you install the Nuget package, a few files are copied into your project:
```
website root
  \Vev
    \Components
      VevGenericBlockViewComponent.cs
    \Controllers
      VevContentPageController.cs
    \Models
      VevContentPage.cs
      VevGenericBlock.cs
```
These files are for you to change. They contain the minimum of properties and presentation and are part of your project after installing the Nuget package (they are not overwritten during upgrades)

You will typically want to change the VevContentPageController.cs to use a View and render your own `<head>` tag with your own tracking.

### Startup.cs
Add the following to `ConfigureServices` in your `Startup.cs` file:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddVev(_configuration);
    ...
}
```

Note! Depending on how you structure your startup, you might need to inject the `IConfiguration` in the constructur, like this:
```csharp
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        _webHostingEnvironment = webHostingEnvironment;
        _configuration = configuration;
    }

```

# Configuration
The configuration is done as Optimizely Hosting destinations in Vev with corresponding application settings in Optimizely CMS. You can publish as both pages and blocks, and need to create one hosting destionation for each so the Vev designer can choose how to publish the content.

## Preparing content in the CMS
After you have installed the Nuget package, it is time to prepare the CMS to allow content coming from Vev. 

You need to create a *Container page* in your content tree, and a *Container folder* in your Blocks tree. The type is not important, it just needs to be a page and folder that allows new sub pages and blocks.

Here we have created a page on an Alloy site:\
![container-page.png](img%2Fcontainer-page.png)\
We can also see that the page id is 102, which is important for later

The same goes for blocks, here we have created a block folder on an Alloy site:\
![container-folder.png](img%2Fcontainer-folder.png)\
We have called it "Vev", you can call it whatever you want, and we can also see that the ID of the folder is 103, which we'll use in the configuration later on.

After you have built the project you'll find some new content types in your project:\
![admin-content-types.png](img%2Fadmin-content-types.png)

For the configuration later on, we need the content id of the *Vev Content Page* and *Vev Content Block*. You can find the ID of the blocks by looking in the URL of the page in admin mode for each content type:\
![admin-content-types-page.png](img%2Fadmin-content-types-page.png)

Make a note of both the id values.

## Create new hosting destination in Vev
The hosting destination tells Vev how to talk to your specific site(s).  
 1. In Vev, go to your [account hosting page]([url](https://editor.vev.design/account/hosting))
 1. Click "Create Hosting"\
![create-hosting-1.png](img%2Fcreate-hosting-1.png)    
 1. Add the domain of your web site (you will typically also add non production domains to help test the integration). If the address to your web site is `https://www.epicphoto.no/` then use `www.epicphoto.no` as the Custom Domain setting.
 1. Select the "Advanced hosting option" and select "Optimizely sync" in the dropdown
 1. For production domains, you will probably want to toggle the Access options setting to make this hosting destination available to everyone on your team\
![create-custom-domain-step1.png](img%2Fcreate-hosting-2.png)
 1. Click Create Hosting button, this takes you to the settings page\
![create-hosting-3.png](img%2Fcreate-hosting-3.png)
 1. Copy the "Hosting ID" for later
 1. Enter a display name, like "Epic Photo Pages"
 1. The "Optimizely Domain" should be prefilled with the domain value from the previous page (if not, just enter the same value here)
 1. Under Security, click the Generate button to generate a value used to sign the content sent from Vev to Optimizely CMS. **Important!** Copy the value as you will need this later, it cannot be retrieved after you close the dialog.\  
![create-custom-domain-secret.png](img%2Fcreate-custom-domain-secret.png)
 1. Add the following to your appSettings.json in your project\  
```json
{
  "Vev": {
    "Enabled": true,
    "Hosting": [
      {
        "HostingId": "<the Hosting ID from above>",
        "Name": "<The Name from above>",
        "ContentContainerId": "<The id of the page where all new published Vev pages should go>", 
        "ContentTypeId": "<The id of the page type to use for publishing. You can find this in CMS admin mode>",
        "PublishingType": 1, 
        "SignatureToken": "<the secret you copied from the hosting>",
        "SaveAsDraft": false
      }
    ]
  }
```  
 12. Repeat these steps to create a new hosting destination for Blocks as well, use `"PublishingType": 2` for blocks.
 1. When your site has been deployed with the new settings, you can click the Test Connection, and it will check if the integration works. If you get an error, please check the `SignatureToken` value in your configuration.
 1. You are now ready to publish from Vev to Optimizely

### Example Configuration
```json
"Vev": {
    "Enabled": true,
    "Hosting": [
      {
        "HostingId": "1hkoopdc5-fn891",
        "Name": "Epic Photo production (block)",
        "ContentContainerId": 103,
        "ContentTypeId": 25,
        "PublishingType": 2, // Block
        "SignatureToken": "FWxNQIaf...k80FPqibemmh9Rx5AWW6YcYL/O0NER3VXffQ==",
        "SaveAsDraft": false
      },
      {
        "HostingId": "1hl01eb47-b8lv",
        "Name": "Epic Photo production (page)",
        "ContentContainerId": 102,
        "ContentTypeId": 26,
        "PublishingType": 1, // Page
        "SignatureToken": "dVGOt56ydHz...ax9dRYlfyza3hfvEmvzLRRrYWWFZg==",
        "SaveAsDraft": true
      }
    ]
  }
```
## Testing locally
During development, it is useful to be able to test the integration in your local environment. This is easy to do with a free [Ngrok](https://ngrok.com) account.

### Steps to test locally
1. ...
1. ...
