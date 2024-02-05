# Vev + Optimizely integration
Create engaging and beatiful designs in [Vev](https://vev.design) and publish easily to your Optimizely CMS or Customized Commerce sites.

## Features
### Publish a page from Vev to Optimizely CMS


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
  Vev
    Components
      VevGenericBlockViewComponent.cs
    Controllers
      VevContentPageController.cs
    Models
      VevContentPage.cs
      VevGenericBlock.cs
```
These files are for you to change. They contain the minimum of properties and presentation and are part of your project after installing the Nuget package (they are not overwritten during upgrades)

You will typically want to change the VevContentPageController.cs to use a View and render your own ´<head>´ tag with your own tracking.

# Configuration
The configuration is done as Optimizely Hosting destinations in Vev with corresponding application settings in Optimizely CMS. You can publish as both pages and blocks, and need to create one hosting destionation for each so the Vev designer can choose how to publish the content.

## Create new hosting destination
 1. In Vev, go to your [account hosting page]([url](https://editor.vev.design/account/hosting))
 1. Click "Create Hosting"
 1. Add the domain of your web site (you will typically also add non production domains to help test the integration). If the address to your web site is https://www.epicphoto.no/ then use ´www.epicphoto.no´ as the Custom Domain setting.
 1. Select the "Advanced hosting option" and select "Optimizelt sync" in the dropdown
 1. For production domains, you will probably want to toggle the Access options setting to make this hosting destination available to everyone on your team
 1. Click Create Hosting
 1. Copy the "Hosting ID" for later
 1. Enter a display name, like "Epic Photo Pages"
 1. The "Optimizely Domain" should be prefilled with the domain value from the previous page (if not, just enter the same value here)
 1. Under Security, click the Generate button to generate a value used to sign the content sent from Vev to Optimizely CMS. **Important!** Copy the value as you will need this later, it cannot be retrieved after you close the dialog.
 1. Add the following to your appSettings.json in your project
 ```
  "Vev": {
    "Enabled": true,
    "Hosting": [
      {
        "HostingId": "<the Hosting ID from above>",
        "Name": "<The Name from above>",
        "ContentContainerId": <The id of the page where all new published Vev pages should go>, 
        "ContentTypeId": <The id of the page type to use for publishing>, // You can find this in CMS admin mode
        "PublishingType": 1, // Page
        "SignatureToken": "<the secret you copied from the hosting>",
        "SaveAsDraft": false
      }
    ]
  ```
  12. Repeat these steps to create a new hosting destination for Blocks as well, use ´"PublishingType": 2´ for blocks.
  13. When your site has been deployed with the new settings, you can click the Test Connection, and it will check if the integration works.
  14. You are now ready to publish from Vev to Optimizely

### Example Configuration
```
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
"" Testing locally
During development, it is useful to be able to test the integration in your local environment. This is easy to do with a free [Ngrok](https://ngrok.com) account.

### Steps to test locally
1. ...
1. ...
