---
layout: post
title: Clojure, Cursive - Resolving "cannot be resolved"
description: Brief description of how to solve a common error in Cursive, the Clojure IDE
permalink: /clojure-cursive-httpkit-resolution
---

Recently I've been using [http-kit](https://github.com/http-kit/http-kit) quite a bit when working with Clojure. The main things I like about it are the sensible defaults, async by default, and being able to set a timeout.

Aside from this I also use [Cursive](https://cursive-ide.com/). As such I had a small issue where when using `httpkit.client` functions, cursive was unable to figure out what the functions under `client` are. The reason for this looks to be because `httpkit.client` [uses a macro to generate it's functions](https://github.com/http-kit/http-kit/blob/56bf0bad71bf419819d0bd788b70f0ec5a36cea9/src/org/httpkit/client.clj#L297) relating to requests called `defreq`.

This `defreq` is something that Cursive doesn't seem to recognise as generating a function, so as such you end up with this error: `org.httpkit.client/get cannot be resolved` although the function will work as expected.

![cursive cannot be resolved error](https://user-images.githubusercontent.com/1202911/105392572-419eeb00-5c13-11eb-9115-df772d62242f.png)

This annoyed me for a little while so I looked into it a bit further and asked around on the lovely [Clojurians slack](https://slofile.com/slack/clojurians), which is a great community.

It wasn't long before someone was able to give me an answer on how to resolve this.

You can see the conversation [here](https://clojurians-log.clojureverse.org/cursive/2021-01-21) in the Clojurians slack archive, but I've also replicated the instructions below in case that gets lost for whatever reason.

To fix it:

- Go to the defreq macro definition in `httpkit.client`
- Put the cursor on the defreq and `alt-enter` to bring up the suggestions
- Choose "Resolve defreq as..."

![image](https://user-images.githubusercontent.com/1202911/105392618-4cf21680-5c13-11eb-8c16-f2eb527dc91a.png)
- Select "Specify" and then type in "Declare" in the var name, picking the one from `clojure.core`

![image](https://user-images.githubusercontent.com/1202911/105392671-5a0f0580-5c13-11eb-8f56-5de655248076.png)

This should then resolve it. You can see a list of your definitions in the settings, too, under Settings → Languages & Frameworks → Clojure → Symbol Resolution

All in all this was another nice interaction with the Clojure community.



