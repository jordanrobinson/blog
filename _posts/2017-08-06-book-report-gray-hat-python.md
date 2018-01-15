---
layout: post
title: Book Report - Gray Hat Python
description: Thoughts on the book "Gray Hat Python" by Justin Seitz
permalink: /gray-hat-python
---

## Introduction

Gray Hat Python, by Justin Seitz and published by no starch press, is a pretty neat book on security, from an entirely Python standpoint. It has a website here: https://nostarch.com/ghpython.htm which I'd recommend checking out.

It looks like this:

![gray-hat-python-cover](https://user-images.githubusercontent.com/1202911/34956204-0c7f7276-fa20-11e7-80cf-c82d027a8f0c.jpg)

This blog post is part of my "Book Report" series, where while reading a book I've been recommended I'll take informal notes on each chapter and then type them up at the end as a blog post I can reread later as both a refresher and a place to note down my thoughts on the book in general.

## Chapter Breakdown

### Chapter 1: Setting Up Your Development Environment

Nothing really groundbreaking in this chapter. Interestingly though it has pretty much the only mention of using Linux in the entire book, which is definitely a surprise.

### Chapter 2: Debuggers and Debugger Design

### Chapter 3: Building a Windows Debugger 

These two chapters are the real meat of the book, the first being a nice introductory preface that prepares you for the second.

My only criticism of these two would be that there's quite a lot of compiler and assembly info in chapter two which isn't then relevant in chapter three. That's not to say that the information isn't useful, it just might have been better structured after the content of chapter three.

Coding up a debugger is a great exercise. Overall this is definitely the best and most interesting section of the book, and the price is worth it for these two chapters alone.

### Chapter 4: PyDbg — A Pure Python Windows Debugger

### Chapter 5: Immunity Debugger — The Best of Both Worlds 

This follows up the debugger exercises nicely, with a lot of information on the tools named in the respective chapters. This is where it did start to get a lot more difficult to run the code in the book due to the age of the book, and Windows generally not playing particularly nicely with Python a lot of the time. 

### Chapter 6: Hooking

### Chapter 7: DLL and Code Injection 

These chapters were quite a bit tricker than the previous ones, I also had quite a bit of trouble getting anything working from the code samples here. The examples were concise and made sense, though, also being very interesting.

### Chapter 8: Fuzzing 

### Chapter 9: Sulley 

### Chapter 10: Fuzzing Windows Drivers 

### Chapter 11: IDAPython — Scripting IDA Pro 

Fuzzing is a pretty interesting topic, and it's covered very well here. I will say again it was difficult to run the code samples, but the information itself was very interesting. When it comes to the drivers however I'm not sure how valid the information still is, since it references Windows XP quite a bit.

### Chapter 12: PyEmu — The Scriptable Emulator 

If I understand this chapter correctly, this shows you how to emulate a small part of a program you might be trying to crack or fuzz, so that you can iterate faster. This chapter was a little weaker than the others and I got the impression that this was potentially one of the chapters that hadn't aged the best.

## Closing notes

This was a light but pretty great read. I'm looking forward to reading the sequel. My only criticisms would be that there were a few chapters that were a little difficult to follow along, particularly due to the age of the book. A lot of the examples will only work on a 32 bit machine. As well as this, choosing Windows seems odd for a lot of the tasks, due to how finicky Python and its tooling can be on the system.

But definitely a good read with a lot of insightful code and information.
