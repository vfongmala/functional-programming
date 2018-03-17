# Chapter 3: Defining Functions

## Part 1

### Lambda Expression:

Functions can be constructed without naming the functions by using **lambda expression**
```
\ x -> x+x
```

#### Why are Lambda's Useful??
Lambda expression can be used to give a formal meaning to function defined by **currying**

##### Example

```Haskell
add x y = x + y

add = \ x -> (\ y -> x+y)
```

Lambda expressions are useful when defining functions that return **functions as results**

##### Example
```Haskell
const   :: a -> b -> a
const x _ = x

is more naturally define by

const   :: a -> (b -> a)
const x = \ _ -> x
```

Lambda expression can be used to avoid naming functions that want to use only once

##### Example
```Haskell
odds n =  map f [0..n-1]
          where
            f x = x*2 +1

can be simplified to

odds n = map (\ x -> x*2 + 1) [0..n-1]
```

### Section
Allow to do the operation without naming function

```Haskell
> 1+2
3

> (+) 1 2
3
```
This also allow one argument of the operator to be include in parentheses
```Haskell
> (1+) 2
3
> (+2) 1
3
```

```Haskell
(1+) successor function
(1/) reciprocation function
(*2) doubling function
(/2) halving function
```
