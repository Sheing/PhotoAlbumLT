# PhotoAlbumLT
A simple console application that displays photo ids and titles in an album through online web service, implemented basic unit testing.

Language: C#

IDE: Visual Studio 2017

## How to Use?
(1) Git clone repo

(2) Open project solution PhotoAlbumLT.sln

(3) Build & Run

## How it Works?
--Enter valid integer value when asked which photo album to select.

--If value is invalid, error message will be prompted.

--If album number does not exist, you will be prompted to enter another number.

--Enter N to exist or anything else to continue.

## Unit Test Coverage
Coverage score: 73%

Things to improve in the future:

Create a Mock HTTPclient to test GetAsync method by faking callouts output. This will test if the callouts actually return value we wanted or allow us to test NullException.


## DEMO
![](https://i.imgur.com/4lxwC1c.gif)
