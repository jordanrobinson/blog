---
layout: post
title: Announcing awaitility-clj
description: An introduction to using awaitility-clj, a Clojure wrapper for Awaitility
permalink: /awaitility-clj-library
---

As you may have guessed from my [earlier post on Awaitility](/awaitility-clojure), currently at work I'm working with a lot of asynchronous systems. As a result, it made sense to make things a bit slicker in terms of testing them.

So, to do this I've wrapped the code from the previous post into a clojure library called `awaitility-clj` that can be found here:

Github: [https://github.com/mypulse-uk/awaitility-clj](https://github.com/mypulse-uk/awaitility-clj)

Clojars: [https://clojars.org/ai.mypulse/awaitility-clj](https://clojars.org/ai.mypulse/awaitility-clj)

And using it is as simple as

{% gist 483283e8bca3aa04db90f36eb5bc5644 awaitility.clj %}

Hopefully people will find this as useful as I have been. At the minute it only supports a small amount of the arguments and config that the Java Awaitility does, but pull requests are encouraged and greatly appreciated.
