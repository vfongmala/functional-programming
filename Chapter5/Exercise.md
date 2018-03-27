# Chapter 5: Exercise

#### Exercise 0
Definitions of the exponentiation operator ^ for non-negative integers (including 0).

*Answer*
```haskell
m ^ 0 = 1
m ^ n = m * m ^ (n - 1)

m ^ 0 = 1
m ^ n = m * (^) m (n - 1)
```

#### Exercise 1
Show how `length [1,2,3]` evaluate
```Haskell
length        :: [a] -> Int
length []     = 0
length (_:xs) = 1 + length xs
```

*Answer*
```Haskell
length [1,2,3]
= { applying length }
1 + length [2,3]
= { applying length }
1 + (1 + length [3])
= { applying length }
1 + (1 + (1 + length []))
= { applying length }
1 + (1 + (1 + 0))
= { applying + }
1 + (1 + 1)
= { applying + }
1 + 2
= { applying + }
3
```

#### Exercise 2
Show how `drop 3 [1, 2, 3, 4, 5]` evaluate
```Haskell
drop          :: Int -> [a] -> [a]
drop 0 xs     = xs
drop n []     = []
drop n (_:xs) = drop (n-1) xs
```

*Answer*
```Haskell
drop 3 [1,2,3,4,5]
= { applying drop }
drop 2 [2,3,4,5]
= { applying drop }
drop 1 [3,4,5]
= { applying drop }
drop 0 [4,5]
= { applying drop }
[4,5]
```

#### Exercise 3
Show how `init [1, 2, 3]` evaluate
```Haskell
init        :: [a] -> [a]
init [_]    = []
init (x:xs) = x : init xs
```

*Answer*
```Haskell
init [1,2,3]
= { applying init }
1 : init [2,3]
= { applying init }
1 : 2 : init [3]
= { applying init }
1 : 2 : []
= { list notation }
[1,2]
```

#### Exercise 4
All correct definitions for the function that decides if all logical values in a list are True:

`and :: [Bool] -> Bool`

*Answer*
```Haskell
#1
and []      = True
and (b:bs)  = b && and bs

#2
and []      = True
and (b:bs)
  | b         = and bs
  | otherwise = False

#3
and []      = True
and (b:bs)
  | b == False  = False
  | otherwise   = and bs

#4
and []      = True
and (b:bs)  = and bs && b
```

#### Exercise 5
Correct definition for the function that concatenates a list of lists:

`concat :: [[a]] -> [a]`

*Answer*
```Haskell
concat []       = []
concat (xs:xss) = xs ++ concat xss
```

#### Exercise 6
Correct definition for the function that produces a list with n identical elements

`replicate :: Int -> a -> [a]`

*Answer*
```Haskell
replicate 0 _ = []
replicate n x = x : replicate (n - 1) x
```

#### Exercise 7
Correct definition for the function that selects the `n` th element of a list. We start counting at 0.

`(!!) :: [a] -> Int -> a`

*Answer*
```Haskell
(x:_)  !! 0  = x
(_:xs) !! n = xs !! (n - 1)
```

#### Exercise 8
Correct definition for the function that decides if a value is an element of a list:

`elem :: Eq a => a -> [a] -> Bool`

*Answer*
```Haskell
elem _ [] = False
elem x (y:ys)
  | x == y = True
  | otherwise = elem x ys
```

#### Exercise 9
Correct definition for the function `merge :: Ord a => [a] -> [a] -> [a]` that merges two sorted lists in ascending order to give a single sorted list in ascending order. For example:
```
> merge [2, 5, 6] [1, 3, 4]
[1, 2, 3, 4, 5, 6]  
```

*Answer*
```Haskell
merge [] ys = ys
merge xs [] = xs
merge (x:xs) (y:ys)
  = if x <= y then x : merge xs (y:ys) else y : merge (x:xs) ys
```

#### Exercise 10
Correct definition for the function `msort :: Ord a => [a] -> [a]` that implements merge sort, in which the empty list and singleton lists are already sorted, and any other list is sorted by merging together the two lists that result from sorting the two halves of the list separately. The solutions can use the function merge from the previous exercise and the function halve that splits a list into two halves whose lengths differ by at most one.

```Haskell
halve :: [a] -> ([a], [a])
halve xs = splitAt (length xs `div` 2) xs
```

*Answer*
```Haskell
msort []  = []
msort [x] = [x]
msort xs = merge (msort ys) (msort zs)
  where (ys,zs) = halve xs
```
