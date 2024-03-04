# Example code to include in your project
Choose the example that suits your needs the most and copy the relevant files into your project.

The folder structure follows standard asp.net MVC structure. If you have a different folder structure in your project, you might want to move files around to your liking.

After you have copied all files, you should do a search and replace for `YourProject` to the root namespace of your project.

## Advanced (recommended)
Has controllers, models and views. Mimics the layout model from the Alloy sample site and inherits from SitePageData.

This makes it easy to show and hide the header and footers, which are set to hidden by default.

Using this takes a little bit more than the simple example.

## Simple
Only contains controllers and models, no views. Will render content from Vev directly as HTML, without using a separate view.

Does not inherit from any site specific classes.

Ready to run out of the box (after search & replace).