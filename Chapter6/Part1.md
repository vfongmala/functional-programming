# Chapter 6: Higher-Order Functions

## Part 1

### Introduction
Higher-order function *takes* a function as an **Argument** or *return* a function as a result

```Haskell
twice     :: (a -> a) -> a -> a
twice f x = f (f x)
```

### Benefits
*Common programming idioms* can be encoded as functions within the language itself.

*Domain specific languages* can be defined as collections of higher-order functions.

*Algebraic properties* of higher-order functions can be used to reason about programs.

#### The Map Function
`map` function applies function to every element of a list
```Haskell
map :: (a -> b) -> [a] -> [b]
// define with list comprehension
map f xs = [f x | x <- xs]
// define with recursion
map f [] = []
map f (x:xs) = f x | map f xs

// example
> map (+1) [1,3,5,7]
[2,4,6,8]
```

#### The Filter Function
`filter` function select every element from a list that match a predicate
```Haskell
filter :: (a -> Bool) -> [a] -> [a]
// define with list comprehension
filter p xs = [x | x <- xs, p x] /*if p x is true then append x*/
//define with recursion
filter p [] = []
filter p (x:xs)
  | p x       = x : filter p xs
  | otherwise = filter p xs

// example
> filter even [1..10]
[2,4,6,8,10]
```
