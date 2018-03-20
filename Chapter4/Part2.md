# Chapter 4: List Comprehension

## Part 2

### List Comprehension

#### Zip function
```Haskell
zip :: [a] -> [b] -> [(a,b)]
```

##### Example
```Haskell
> zip ['a','b','c'] [1,2,3,4]
[('a',1),('b',2),('c',3)]
```

##### Usage
`pairs` function is use for pairing item in the list with the next item of itself
```Haskell
pairs :: [a] -> [(a,a)]
pairs xs = zip xs (tail xs)

// example
> pairs [1,2,3,4]
[(1,2),(2,3),(3,4)]
```

`sorted` function is use for check if the items in the list are sorted by making a list of pair and check if first item of each pair has less value than second item or not
```Haskell
sorted :: Ord a => [a] -> Bool
sorted xs =
  and [x <= y | (x,y) <- pairs xs]

// example
> sorted [1,2,3,4]
True
> sorted [1,3,2,4]
False
```

`positions` function is use for define position of a value in the list
by create pair of item of the list with position (from `[0..n]` list) and filter only the one that item in the list match with input value `x` and take all of the positions `i` out as a list
```Haskell
positions :: Eq a => a -> [a] -> [Int]
positions x xs =
  [i | (x', i) <- zip xs [0..n], x == x']
  where n = length xs - 1

// example
> positions 0 [1,0,0,1,0,1,1,0]
[1,2,4,7]
```

### String Comprehension
String is a list of characters. So string can work as the list
```Haskell
"abc" :: String
// is same as
['a','b','c'] :: [Char]
```

```Haskell
> length "abcde"
5

> take 3 "abcde"
"abc"

> zip "abc" [1,2,3,4]
[('a',1),('b',2),('c',3)]
```

##### Usage
`lowers` function is use for counting lower case character in the given string by return the length of the list of lower character from `xs`
```Haskell
lowers :: String -> Int
lowers xs =
  length [x | x <- xs, isLower x]

// example
> lowers "Haskell"
6
```
