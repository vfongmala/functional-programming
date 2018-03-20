# Chapter 4: Exercise

#### Exercise 0
Expression that calculate the sum 1^2+...+100^2

*Answer*
```Haskell
> sum 100 = sum [x ^ 2 | x <- [1..100]]
```

#### Exercise 1
Implementation of `replicate :: Int -> a -> [a]`

*Answer*
```Haskell
> replicate 3 True
[True, True, True]

> replicate n a = [a | _ <- [1..n]]
```

#### Exercise 2
Implementation of pythagorean
`pyths :: Int -> [(Int, Int, Int)]`

*Answer*
```Haskell
> pyths 10
[(3, 4, 5), (4, 3, 5), (6, 8, 10), (8, 6, 10)]

> pyths n =
    [(x,y,z) | x <- [1..n], y <- [1..n], z <- [1..n], x ^ 2 + y ^ 2 = z ^ 2]
```

#### Exercise 3
A positive integer is perfect if it equals the sum of its factors, excluding the number itself. Choose the correct definition of the function `perfects :: Int -> [Int]` that returns the list of all perfect numbers up to a given limit.

Note: `factors` is not a library function but is defined in the lecture.

*Answer*
```Haskell
> perfects 500
[6, 28, 496]

> perfects n = [x | x <- [1..n], isPerfect x]
    where isPerfect num = sum (init (factors num)) == num
```

#### Exercise 4
The following list comprehension:
`[(x,y) | x <- [1,2,3], y <- [4,5,6]]`
can be re-expressed using two or more comprehensions with single generators. Choose the implementation that is equivalent to the one above.

*Answer*
```Haskell
concat [[(x,y) | y <- [4,5,6]] | x <- [1,2,3]]
```

#### Exercise 5
Redefine the function positions discussed in the lecture, using the function find:
```Haskell
find :: (Eq a) => a -> [(a,b)] -> [b]
find k t = [v | (k', v) <- t, k == k']

positions :: (Eq a) => a -> [a] -> [Int]
```
*Answer*
```Haskell
positions x xs = find x (zip xs [0..n])
  where n = length xs - 1
```

#### Exercise 6
The scalar product of two lists of integers xs and ys of length n is given by the sum of the products of corresponding integers:

`sum ( (xs !! i) * (ys !! i) ) for i = 0 to n-1`
Choose the correct definition of `scalarproduct :: [ Int ] -> [ Int ] -> Int` that returns the scalar product of two lists.
```Haskell
> scalarproduct [1, 2, 3] [4, 5, 6]
32
```
*Answer*
```Haskell
> scalarproduct xs ys = sum [x * y | (x,y) <- xs `zip` ys]
```

#### Exercise 7
*Answer* is in `Caesar.hs` file

#### Exercise 8
Evaluating `[(x, y) | x <- [1, 2], y <- [1, 2]]` gives:

*Answer*

`[(1,1),(1,2),(2,1),(2,2)]`

#### Exercise 9
Evaluating `[x | x <- [1, 2, 3], y <- [1..x]]` gives:
*Answer*

`[1,2,2,3,3,3]`

#### Exercise 10
Evaluating `sum [x | x <- [1..10], even x]` gives:

*Answer*

`30`

#### Exercise 11
The equation `xs = 1 : [x + 1 | x <- xs]` defines:

*Answer*

`xs = [1,2,3,...]`

#### Exercise 12
Choose the correct definition of the function `riffle :: [a] -> [a] -> [a]` that takes two lists of the same length and interleaves their elements in turn about order.

`riffle [1,2,3] [4,5,6] = [1,4,2,5,3,6]`

*Answer*

``riffle xs ys = concat [[x,y] | (x,y) <- xs `zip` ys]``

#### Exercise 13
Choose the correct definition for the function divisors :: Int -> [Int] that returns the divisors of a natural number.

For example:
`divisors 15 = [1, 3, 5, 15]``
The function `divides :: Int -> Int -> Bool` decides if one integer is divisible by another. (Note: You need to implement this function yourself.)

For example:
```
divides 15 2 = False
divides 15 3 = True
```

*Answer*

``divisors x = [d | d <- [1..x], x `divides` d]``
