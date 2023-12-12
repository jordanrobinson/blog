---
layout: post
title: On using Zenity and Cron to remind me to go for lunch
description: How to massively overengineer going for lunch
permalink: /zenity-and-cron-for-lunch
---

Sometimes, I'll get really caught up in a problem or meeting and find that actually, I was meant to go for lunch a little while ago.

Since lunchtime and a break from a problem is often the best debugger, I had a quick look into how to automate a reminder. While there are a million ways to remind yourself of upcoming meetings or tasks, I wanted something quite simple that I could dismiss easily and wasn't tied to a work or personal calendar system.

What I ended up going with and have been using for a few months now is a quick solution that uses Cron and Zenity.

I simply

`crontab -e`

To open up my crontab and edit it.

Then put in the zenity command, which looks like this:

`30 12 * * * zenity --info --text "<span foreground=\"white\" font=\"64\">Go and grab some 🍜</span>\n\n" --no-wrap --display=:0.0`

And this pops up with a handy reminder each day.

![image](https://github.com/jordanrobinson/blog/assets/1202911/4f72aaf3-9e70-48ef-bdd8-9a5b0ad83669)

This might be a bit hard to parse on first glance so let me break it down:

`30 12 * * *` is the cron task, saying, do this every day at 12:30.

`zenity` is the program that allows you to pop up a graphical window.

`--info --text "<span foreground=\"white\" font=\"64\">Go and grab some 🍜</span>\n\n"` is the contents of the message. Here we're saying to use an info icon, as well as denoting the size and style of the text.

`--no-wrap` is just stylistic here, I found without it the alert was hard to read.

and `--display=:0.0` is specifying what monitor to show the alert on.

And that's it!