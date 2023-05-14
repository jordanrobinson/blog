---
layout: post
title: Cursive - Fixing other issues when resolving symbols
description: Brief description of how to solve a common error in Cursive, the Clojure IDE
permalink: /clojure-cursive-fixing-symbol-resolution
---

It's been a good while since my last post [on this](https://blog.jordanrobinson.co.uk/clojure-cursive-httpkit-resolution), but I found something pretty relevant to it so thought a follow-up would make good sense. 

When you're trying to resolve things in Cursive, this intention in IntelliJ sometimes won't appear, the reasoning for this is actually due to a hidden-away setting in the editor intentions menu of IntelliJ.

I'm not sure what causes this to be turned off, but I've seen it happen to other people a few times.

The setting is located here in the settings menu:

![image](https://user-images.githubusercontent.com/1202911/191520357-d636e132-1fbe-422c-824d-c5726551377a.png)

And once you've turned it on again then custom symbol resolution will work exactly as it did before.
