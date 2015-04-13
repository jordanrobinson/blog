---
layout: post
title: How to clear watched JIRA issues using the JIRA CLI
description: Clearing out all those old jira cases from your watch list in one fell swoop.
---

As bugtrackers go, JIRA is my poison of choice. It's definitely one of the better bugtrackers out there, pretty feature rich and definitely beats a pen, paper and a vague description.

However, while most of those features are great, some can be a bit of a double-edged sword. In particular, watched cases can stack up and give you no end of notifications from comments and activity, drowning out the useful information and meaning you can't make out the signal from the snow.

So after your watched cases have stacked up, you just clear out them all by pressing a button right? Not so easy. Atlassian haven't yet put in a method to clear all cases, so we have to improvise a little.

To clear all your cases, first off we're going to need Python, so go on and grab version <code>2.7.9</code> and check you've got it working from the command line. For me I use bash, but this approach will also work in Terminal and I'm pretty sure with a little ingenuity and adaptation, it will work in good old CMD or Powershell.

Once we've got Python fired up and we can check the version from the command line (<code>python --version</code>, for your convenience) the next step is to install pip, the python package manager. Pip is found [here](https://pip.pypa.io/en/latest/installing.html) and we need it to grab the JIRA command line interface, which is a pretty powerful tool. There are a few of them available, but my favourite is [this one](https://github.com/toabctl/jiracli) which has the source on github and checks all the boxes we need.

From the JIRA CLI, we can do and automate all kinds of powerful stuff like scripts, cron jobs and basically whatever you feel like. As for clearing all your watched JIRA cases, this is as simple as getting a list of the cases, parsing them a little, and letting JIRA know we don't want to watch them anymore, so the command for that is as follows:

{% gist 20aff742fc8f7b1bd77e %}
 
Like I mentioned, this is the bash version of what you need to do, so with a little adaptation this can be applied to a powershell script. If you're the kind soul that does this, drop me an email and I'll make sure to update the post and give you credit.
