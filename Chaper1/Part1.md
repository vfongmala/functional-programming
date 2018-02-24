Chapter 1: First Step

Part 1

Functional Programming using Haskell language

Installation
- Download Haskell Platform from https://www.haskell.org/platform/
- Install on the machine

Usage
- Open terminal
- Type 'ghci'
- Now can start using Haskell

Sample expression
- `x^y` -> x power by y
- `sqrt(x)` -> square root of x
- `[1,2,3]` -> list of 1,2,3
- `head[]` -> return first item of a list
- `tail[]` -> return list of items except first item of a list
- `[] !! n` -> return nth item of a list
- `take n []` -> return first n items of a list
- `drop n []` -> remove first n items from a list
- `length []` -> return length of a list
- `sum []` -> calculate sum of a list of number
- `product []` -> calculate product of a list of number (multiply)
- `[] ++ []` -> append 2 lists
- `reverse[]` -> reverse a list

Function application (Haskell)
- function application is denote using space
-- example
-- `f a b` => f(a,b)
-- `f a b + c*d` => f(a,b) + c*d
-- `f a + b` => f(a) + b
-- `f (g x)` => f(g(x))
-- `f x (g y)` => f(x, g(y))
-- `f x * g y` => f(x)*g(y)
