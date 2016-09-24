---
layout: post
title: Packaging Sitecore items to move them between environments
description: Packaging items up happens a lot when working with multiple environments, so let's go through the steps
---

## Packages in Sitecore

Packaging items up in Sitecore is the easiest way to move things between environments. Often, there's an issue on a server that someeone else is testing on, that has a bug related to the content on that server. Instead of creating the content yourself on your local or development server, it's much easier to simply package that content up and move it over to your own environment.

## Creating a Package

Creating a package in Sitecore is pretty simple, and although it's changed a little in Sitecore 8, the general process is the same, first off we select the `package designer` from the start menu shown here:

![alt text](https://blog.jordanrobinson.co.uk/public/images/package1.jpg)

After that this gives you a wizard that looks like this, which has a few details that we can fill in. This will be reflected in the metadata of the package. Additionally, in Sitecore 8, this now reflects in the filename of the zip, too.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package2.jpg)

On this menu, we just need to select the `Items statically` button, so we can add something from the content tree. While there are a lot of options up here, let's keep it simple for now and just create a basic package.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package3.jpg)

Adding the items is pretty simple, just select them in the dialog, and you'll be asked for a source name. This isn't really shown anywhere and is only used if we have multiple sources, which for this package, we won't.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package4.jpg)

Now we've added the items, we just need to generate a zip from the package. This is done from the main menu back on the package designer screen. We can also save it here if we're ever likely to need to generate a similar package in the future.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package5.jpg)

This gives another short wizard that asks for a name:

![alt text](https://blog.jordanrobinson.co.uk/public/images/package6.jpg)

And then lets you download the package. Success! Another quick change introduced in Sitecore 8 is that the download button is now a lot bigger, since it was pretty easy to miss in previous versions.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package7.jpg)

## Installing the Package

Now we have our package, it's a pretty simple process to install it onto the environment of our choosing, first off, select the `Installation Wizard` (Note this is found in the control panel in older versions of Sitecore).

![alt text](https://blog.jordanrobinson.co.uk/public/images/package8.jpg)

Then, you'll be asked to choose the package to install. Since we haven't uploaded it to the server yet, let's pick `Upload package` here.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package9.jpg)

Upload the package from your filesystem...

![alt text](https://blog.jordanrobinson.co.uk/public/images/package10.jpg)

Then install it, note the info shown here should be the details we entered previously.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package11.jpg)

The final step is simply to restart the client if necessary, then check if your content moved across successfully.

![alt text](https://blog.jordanrobinson.co.uk/public/images/package12.jpg)

That's all you need to do to move content across, Sitecore will even create the parent folders of the content for you if needed.
