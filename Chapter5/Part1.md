# Chapter 5: Recursive Functions

## Part 1

### Introduction
There's a way to define `factorial` function by using `product` function as example
```Haskell
factorial   :: Int -> Int
factorial n = product [1..n]

// example
factorial 4
=
product [1..4]
=
product [1,2,3,4]
=
1*2*3*4
=
24
```

But `factorial` function can be implemented by using recursive approach as following
```Haskell
factorial 0 = 1
factorial n = n * factorial (n-1)

// example
factorial 3
=
3 * factorial 2
=
3 * (2 * factorial 1)
=
3 * (2 * (1 * factorial 0))
=
3 * (2 * (1 * 1))
=
3 * (2 * 1)
=
3 * 2
=
6
```

### Recursion on Lists
```Haskell
product         :: [Int] -> Int
product []      = 1
product (n:ns)  = n * product ns

// example
product [2,3,4]
=
2 * product [3,4]
=
2 * (3 * product [4])
=
2 * (3 * (4 * product []))
=
2 * (3 * (4 * 1))
=
2 * (3 * 4)
=
2 * 12
=
24
```

`length` function calculate length of the given list
```Haskell
length        :: [a] -> Int
length []     = 0
length (_:xs) = 1 + length xs
```

`reverse` function create list in reverse order of given list
```Haskell
reverse         :: [a] -> [a]
reverse []      = []
reverse (x:xs)  = reverse xs ++ [x]
```

### Multiple Arguments
`zip` function create list of pair of items of two lists
```Haskell
zip               :: [a] -> [b] -> [(a,b)]
zip []  _         = []
zip _   []        = []
zip (x:xs) (y:ys) = (x,y) : zip xs xy
```

`drop` function remove the first n elements of the list
```Haskell
drop          :: Int -> [a] -> [a]
drop 0 xs     = xs
drop _ []     = []
drop n (_:xs) = drop (n-1) xs
```

`(++)` function use for appending two lists
```Haskell
(++)          :: [a] -> [a] -> [a]
[]      ++ ys = ys
(x:xs)  ++ ys = x : (xs ++ ys)
```
