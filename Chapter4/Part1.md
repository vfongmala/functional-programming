# Chapter 4: List Comprehension

## Part 1

### List Comprehension

`x <- [1..5]` is generator
and it can have multiple generators (like nested loop)

##### Examples
```Haskell
[x^2 | x <- [1..5]]
> [1,4,9,16,25]

[(x,y) | x <- [1,2,3], y <- [4,5]]
> [(1,4),(1,5),(2,4),(2,5),(3,4),(3,5)]
```

#### Dependent Generators
##### Examples
```Haskell
[(x,y) | x <- [1..3], y <- [x..3]]
> [(1,1),(1,2),(1,3),(2,2),(2,3),(3,3)]
```

```Haskell
concat    :: [[a]] -> [a]
concat xss = [x | xs <- xss, x <- xs]

concat [[1,2,3],[4,5],[6]]
> [1,2,3,4,5,6]
```

#### Guards
List Comprehension can use **guards** to restrict the value produced by ealier generators

##### Examples
```Haskell
[x | x <- [1..10], even x]
> [2,4,6,8,10]
```

```Haskell
factors :: Int -> [Int]
factors n =
  [x | x <- [1..n], n `mod` x == 0]

> factors 15
[1,3,5,15]
```

```Haskell
prime :: Int -> Bool
prime n = factors n == [1,n]

> prime 15
False

> prime 7
True
```

```Haskell
primes :: Int -> [Int]
primes n = [x | x <- [2..m], prime x]

> prime 40
[2,3,5,7,11,13,17,19,23,29,31,37]
```
