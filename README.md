Hi,

## How I came up with the solution
To solve this problem I was mainly concerned with readability for other developers as there was no specification on speed, memory and extensibility etc.

I came up with the solution of interating through a List<string> on my own as well as potential versions with a dictionary and stack - I then googled this and saw that 
the stack method was used BUT I decided to not go for the List<string> iteration as I believed that this would be easier for others to understand.

## How I solved it
I broke this down into a few steps.
- sanity check string to ensure we can do as we please with it
- split by mathmatical operators
- iterate through doing multiplication and division and then subtraction and addition
- the iteration would go through the items and do the mathmatical operation if matched with specified operator, it would add this to a new list of 'result' strings, that list can be popped if we need to use the newly made result
to then add back to it


I am aware this approach is not very flexible for extension (eg if you later want to add brackets later on) but would be sufficient for the current spec and personal time limits.
I tried to show different areas although minimally given time:
blazor (minimally)
the problem itself
the restful api with appropriate status codes (although not fully implemented client side)
sanity checks
unit tests - AAA standard
authorization filter


## Notes on testing
I have provided some testing but not thorough, there is no integration test for sanity + result and only a few tests for specific functions, ofcourse you can spend a lot of time testing
but I hope I showed competence with the few I implemented

## notes on building
this is a blazor wasm project so you can pull and load then run the SERVER and it should bring up the screen to input text (this is messy but sufficient)

## Would I do this differently next time?
I would likely go for the stack approach if I started over, I realised pretty early that my approach would have more edge cases and although this is an unlimited time exercise, 
I am only able to commit 2-3 hrs to this personally.
