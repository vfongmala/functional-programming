# Chapter 5: Recursive Functions

## Part 2

### Quicksort
`quicksort` algorithm is work by breakdown the list and sort and combine it back together

* The empty list is already sort
* Non-empty lists can be sorted by sorting the tail values <= the head, sorting the tail value > the head, and then appending the resulting lists on either side of the head value

```Haskell
qsort         :: [Int] -> [Int]
qsort []      = []
qsort (x:xs)  =
  qsort smaller ++ [x] ++ qsort larger
  where
    smaller = [a | a <- xs, a <= x]
    larger  = [b | b <- xs, b > x]

// example
qsort [3,2,4,1,5]

                 qsort [2,1] ++ [3] ++ qsort [4,5]

      qsort [1] ++ [2] ++ [] ++ [3] ++ qsort [4,5]

[] ++ [1] ++ [] ++ [2] ++ [] ++ [3] ++ qsort [4,5]

[] ++ [1] ++ [] ++ [2] ++ [] ++ [3] ++ [] ++ [4] ++ qsort [5]

[] ++ [1] ++ [] ++ [2] ++ [] ++ [3] ++ [] ++ [4] ++ [5]

[1,2,3,4,5]
```

`replicate` function produce a list with n identical element
```Haskell
replicate :: Int -> a -> [a]
```

`(!!)` function select nth element of a list
```Haskell
(!!) :: [a] -> Int -> a
```

`elem` function decide if a value is an element of a list
```Haskell
elem :: Eq a => a -> [a] -> Bool
```
