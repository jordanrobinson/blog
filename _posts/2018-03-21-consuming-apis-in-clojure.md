---
layout: post
title: Hacking up a quick API consuming service in Clojure
description: A basic overview of putting together a small app that consumes an api endpoint in clojure
permalink: /clojure-api-consumer
---

## Clojure?

If you're reading this you probably already have a good idea of what Clojure is. Just in case though, [Clojure](https://clojure.org/) is a functional programming language built on top of the JVM, with a lisp-like syntax. Personally I really like Clojure, and wish I had the chance to use it more often. On top of this, while I don't go as much as I should, the Manchester Functional Programming meetup [Lambda Lounge](http://www.lambdalounge.org.uk/) is most certainly one of my favourite meetups, where Clojure is often a hot topic.

At present I'm basically just a novice in Clojure, hacking my way through the occasional side project. 

Which conveniently brings me to one of my current side projects; a service that sends out Slack messages based on the result of an API call changes. On the face of it this sounds like something that could easily be quite tricky, but with Clojure and a few afternoons of hacking the odd piece together as an exercise to learn the language a bit better, it clocked in at just under 80 lines.

Since I'm still learning Clojure, there's a few points I'm not overly proud of, and intend to clean up and release on Github the whole source. Until then though, I thought I'd write something illustrating how easy it is to put something like this together.

## The Code

Naturally, when tackling something like this, the first thing to do is break it up into smaller chunks and see if there's any easy wins. For this service to work, it will need to:

 - Run at an interval
 - Hit an API
 - Send a message if something has changed
 - Store the result somewhere
 - Check against that result next interval

So one at a time

 - Run at an interval

This is very much a solved problem, on every level. In this case we want to do as little work as possible; so let's just use Cron for this. Clojure has great support for compiling to a jar, in this case we just need to compile to an uberjar (a jar with all the dependencies) and then run it just like any other standard Java jar, on a schedule.

 - Hit an API

This is pretty simple, it uses [clj-http](https://github.com/dakrone/clj-http) to hit the endpoint with some basic auth, then [Cheshire](https://github.com/dakrone/cheshire) to parse the json and return it.

{% gist d5383dde0b9c1be1fd0f9ac409965eb3 hit-api.clj %}

 - Send a message if something has changed

For this, we can check if the file is there for a start, then if it has an updated-date property in the previous file (that we're writing) then we can log out that we checked to the console if nothing changed, or write a new update if it has. We also want to write to disk if we have a new version of the result that's changed, which brings us onto our next point.

{% gist d5383dde0b9c1be1fd0f9ac409965eb3 check-file.clj %}

 - Store the result somewhere

In this case we should be fine just storing to disk, since our service is only running every hour or more it doesn't really make sense to keep anything in memory. This is probably the only point where I'd like it if it was split out a bit more, since while these are very short functions, with a name like write-update you wouldn't expect this to send a message as well. Definitely something I'm going to clean up.

{% gist d5383dde0b9c1be1fd0f9ac409965eb3 write-update.clj %}

Then at the end of that, we send our message here:

{% gist d5383dde0b9c1be1fd0f9ac409965eb3 send-slack-message.clj %}

 - Check against that result next interval
 
Then we just need to run the whole thing again, essentially.

Like I say, a lot of this has been edited for brevity and cleaned up a little in the examples. I do intend to have a full cleaned up version on Github at some point soon.

Either way though, I thought this was pretty neat in how quick it was, and a really nice way of thinking about a solution.
