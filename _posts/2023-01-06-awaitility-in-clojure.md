---
layout: post
title: Using Awaitility in Clojure
description: A brief intro to using the testing library Awaitility in Clojure
permalink: /awaitility-clojure
---

## Awaitility

[Awaitility](https://github.com/awaitility/awaitility) is a pretty cool Java library that allows you to wait for asynchronous processes in tests. Lately we've been writing a lot of these kinds of tests where something will happen in an external component, such as Kafka, and we want our system to react to that and then assert on the state of our system. This is quite a tricky process as there's actually more to think about than just a thread sleep call, so using something like Awaitility here is quite nice.

## A Nice Example Problem

Instead of a large complicated problem involving Kafka and databases and various other problems, let's have a small self-contained issue and see what the simplest case we can put together is first, and then from there build it up.

Let's say that we have the following function:

{% gist 32a2e5951997c1139a2ce68afb5e13bb example-code.clj %}

This is pretty simple but it'll basically randomly be above or below the number, so will be either true or false. Here this is basically just a proxy for an asynchronous process elsewhere.

It will output something like

```
Reading is... 0.38765405457829893
Reading is... 0.44857065444098454
Reading is... 0.14205946654844082
```

from the console when run.

Then we want to add Awaitility to our project, so in Leiningen this looks like this:

{% gist 32a2e5951997c1139a2ce68afb5e13bb project.clj %}

This will be slightly different if you are using Deps but you should be able to find a lot of resources for how this should look if so.

Then, let's put together our test. Here we assume that we want to wait until the `check-reactor-is-ready` function returns true, then we can assert on the various properties of that reactor.

{% gist 32a2e5951997c1139a2ce68afb5e13bb test.clj %}

As tests go there's not a lot of code or assertions here but it's actually pretty good. Awaitility will throw if it takes longer than the default timeout of ten seconds, so if our function above doesn't go over 0.5 in that time, our test will fail with an exception. If it doesn't, the assumption is that we are ready to assert on the rest of the system.

You can also compare this to what it would look like if we were using Awaitility in Java:

{% gist 32a2e5951997c1139a2ce68afb5e13bb javaExample.java %}

We can go a bit further with this and do things like change the wait time, which will look like this:

{% gist 32a2e5951997c1139a2ce68afb5e13bb test-two.clj %}

If we then also change the criteria to be a bit more stringent such as `> 0.95`, we should be able to get a timeout if we run a few times.

```
Reading is... 0.14748365188970014
Reading is... 0.39006578072452525
Reading is... 0.11361210088909512
Reading is... 0.3491163467675231
Reading is... 0.7100413898618688
Reading is... 0.4931516769505109
Reading is... 0.9274004405826166
Reading is... 0.776093982387096
Reading is... 0.7668150587110371
org.awaitility.core.ConditionTimeoutException: Condition service.outcomes.resource_test$check_reactor_is_ready was not fulfilled within 1 seconds.
```

Finally let's clean it up a little and put it into a threaded form so it's a bit easier to read:

{% gist 32a2e5951997c1139a2ce68afb5e13bb test-three.clj %}

And that's it for now, just a quick intro but you should be able to build on this quite a bit when testing asynchronous operations.
