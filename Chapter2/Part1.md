# Chapter 2: Types and Classes

## Part 1 - 3

### Type:
- `Bool` : boolean `<True|False>`
- `Char` : single character
- `String`: strings of characters
- `Int` : fixed-precision integers
- `Integer` : arbitrary-precision integers
- `Float` : floating-point numbers

### List Types
- `[False, True, False] :: [Bool]`
- `['a', 'b', 'c', 'd'] :: [Char]`
- `[['a'], ['b', 'c']] :: [[Char]]`

### Tuple Types
A tuple is a sequence of values of **different** type
- `(False, True) :: (Bool, Bool)`
- `(False, 'a', True) :: (Bool, Char, Bool)`
- `(True, [`a`, `b`]) :: (Bool, [Char])`

Note: The type of tuple encodes its size

### Function Types

`f(x) :: t1 -> t2` is function that map value of type `t1` to value of type `t2`

#### Example
- `not :: Bool -> Bool`
- `isDigit :: Char -> Bool`
- `add :: (Int, Int) -> Int`
- `add x y = x+y`

### Curried Functions
- `add' :: Int -> (Int -> Int)`
- `add' x y = x+y`

#### The difference
`add` and `add'` produce the same result but `add` take two arguments at the same time but `add'` take one at the time.

### Currying Conventions
The arrow -> associate to the right
- `Int -> Int -> Int -> Int` means `Int -> (Int -> (Int -> Int))`
- `mult x y z = ((mult x) y) z`

### Polymorphic Function
Function that contains variable of any types
- `length :: [a] -> Int`
`length` function takes list of any types and return length of the list

  remark: `a` equals to `T` in Java

- `length [False, True]` `a = Bool`
- `length [1,2,3,4]` `a = Int`

#### Example
- `fst :: (a,b) -> a` return first element of tuple (with type `a`)
- `head :: [a] -> a` return first item in the list of type `a`
- `take :: Int -> [a] -> [a]` return first `n` elements of the list of `a` and return that list
- `zip :: [a] -> [b] -> [(a,b)]` return list of pair from list of `a` and list of `b`
- `id :: a -> a` return argument value

Note:
type variable must begin with lower-case letter. Usually use `a,b,c`

### Overloaded Functions
Function that has type contains one or more class **constraints**
- `sum :: Num a => [a] -> a`
means function `sum` will take only list of `a` which is type of Num interface
##### Example
```Haskell
  sum [1,2,3]
  > 6
  sum [1.1,2.2,3.3]
  > 6.6
  sum ['a','b','c']
  ERROR // because Char is not Num
```

Haskell has a number of type classes, including
- `Num` : Numeric Types
- `Eq` : Equality Types
- `Ord` : Ordered Types

example
```Haskell
(+) :: Num a => a -> a -> a

(+) 2 3
> 5
```

means `a` have to be type of `Num`. Then take first `a` argument then second `a` argument and return value of type `a`

```Haskell
(==) :: Eq a => a -> a -> Bool

(==) 1 2
> False
```

means `a` have to be type of `Eq`. Then take first `a` argument then second `a` argument and return value of type `Bool`

```Haskell
(<) :: Ord a => a -> a -> Bool

(<) 1 2
> True
```

means `a` have to be type of `Ord`. Then take first `a` argument then second `a` argument and return value of type `Bool`
