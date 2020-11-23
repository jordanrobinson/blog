---
layout: post
title: Clojure - Getting started with Liberator and TDD
description: A brief intro to setting up a simple JSON api through TDD in Clojure, using liberator
permalink: /liberator-tdd
---

## Liberator
[Liberator](https://clojure-liberator.github.io/liberator/) is a library that allows for creation of REST-based endpoints for construction of an API in Clojure. It has a simple set of functions that are quite powerful and allow for a great deal of customisation. It also has a slightly less simple [decision graph](https://clojure-liberator.github.io/liberator/tutorial/decision-graph.html) that makes more sense with experience.

In this post we'll put together a very simple endpoint, by starting first with a test and then progressing from there.

## Getting Started

First off we'll need to run:

{% gist facfae126370a6c26ced361fa8979ce8 new-app.sh %}

Which will set up our project and give us the basics for running our code.

This gives us a failing test and a `-main` function that we can run.

Then, let's add the dependencies to our `project.clj` so that they look like this:

{% gist facfae126370a6c26ced361fa8979ce8 project.clj %}

This will give us the bare minimum libraries that we need to run a server that can accept and respond to requests.

Once we have our libraries we have somewhat of a chicken and egg problem, in that we need to do some basic setup before we can get testing working. First off we want to add a place for our resource that will be using liberator, that should look a bit like this:

{% gist facfae126370a6c26ced361fa8979ce8 resource-start.clj %}

And we'll need to modify our `core.clj` to be able to start something that can respond to web requests. That should look something like this:

{% gist facfae126370a6c26ced361fa8979ce8 core.clj %}

Since this is a more basic tutorial, while we're here let's talk about this in a little bit more detail, there's essentially three parts to this file.

### The core file

{% gist facfae126370a6c26ced361fa8979ce8 core-1.clj %}

First off there are the imports, which are pretty standard. Because this is the `core.clj` generated for us by the `lein` command, we also have a [`:gen-class`](https://clojuredocs.org/clojure.core/gen-class). We're also using [`:require`](https://clojuredocs.org/clojure.core/require) with `:as` to be able to alias the libraries, so we can be more specific in the body of the code, as well as giving meaningful names to things instead of long namespaces.

{% gist facfae126370a6c26ced361fa8979ce8 core-2.clj %}

Then we have the main part of the file, where we define how to start a server. This uses Jetty as well as some ring middleware to be able to start up a server on port 3000 on localhost. There are a few parts to this that may not seem immediately obvious, but the key things to note are that we're using the `defroutes` from our other file here, as well as `:join? false` which will help us out when we go to test our server. 

The reason we have this as a separate function is so that we can call it from both this file, as well as from tests.

{% gist facfae126370a6c26ced361fa8979ce8 core-3.clj %}

Finally we have the main function, which is our entrypoint for if we call `lein run`. For now for us, this just starts the server, but you could happily make this start a database or use something like [components](https://github.com/stuartsierra/component).

## Putting the test in place

Now that we have all the scaffolding for the project, we can put a test in. Thankfully, Leiningen sets most of this up for you. You should currently be able to run `lein test` and see that the example test given fails. Hooray!

For this example, let's assume that the data we want our endpoint to return is.

{% gist facfae126370a6c26ced361fa8979ce8 data.json %}

And as such let's set up a test that looks for this. The first step is to allow us to call our webserver from a test. To do this we'll use `use-fixtures` like so:

{% gist facfae126370a6c26ced361fa8979ce8 test-1.clj %}

This lets us start up the server at the start of the test suite, runs the tests, and stops the server once our tests are done. This is a pretty common pattern in component and integration tests and because we've modularised the starting of our server, we can simply call `start-server` here from our `core.clj` and it will spin up a fresh server for us. In a more complicated setup you would likely want to have this on a random free port instead of using the port hardcoded in `core.clj` but, like most of this example, a lot of it can be swapped out later.

Once we have that, we can add our test, which as a whole file, should look like this:

{% gist facfae126370a6c26ced361fa8979ce8 test.clj %}

Here we're using [http-kit](https://github.com/http-kit/http-kit) to make a simple request to our endpoint, then we're decoding the body with `json/read-str` and comparing it to our expected data.

## Getting to green

Now that we have a red test, we're going to want to turn it green, which in this case is actually a little simpler than the rest of the setup so far. We can make our `resource.clj` look like this:

{% gist facfae126370a6c26ced361fa8979ce8 resource.clj %}

Which adds our route to the `make-routes` function, and uses liberator to define the resource. Of particular note here is the `:handle-ok` which is how Liberator defines what will be returned for the OK status code. This can be a function, so you can have much more complicated implementations than this, but this makes a good start.

With this, we just need to run a `lein test` and our test _should_ be green!

With such a simple example there's not too much refactoring for us to do now, but we can definitely add more tests, like checking the status code of the response, or what happens if we hit an endpoint that isn't yet set up.
