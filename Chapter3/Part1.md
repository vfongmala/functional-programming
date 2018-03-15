# Chapter 3: Defining Functions

## Part 1

### Type: Conditional Expression

Conditional expression must always have `else` branch

```Haskell
if <condition> then <result if condition is true> else <result if condition is false>
```

#### Example
```Haskell
abs :: Int -> Int
abs n = if n >= 0 then n else -n
```

Haskell also can use nested condition

#### Example
```Haskell
signum :: Int -> Int
signum n = if n < 0 then -1 else
              if n == 0 then 0 else 1
```

### Guarded Equations
Alternative to conditionals

```Haskell
abs n | n >= 0    = n
      | otherwise = -n
```

also can use for multiple condition
```Haskell
signum n  | n < 0     = -1
          | n == 0    = 0
          | otherwise = 1
```

### Pattern Matching

Many functions have clear definition so we can use **pattern matching**

```Haskell
not       :: Bool -> Bool
not True  = False
not False = True
```
```Haskell
(&&)      :: Bool -> Bool -> Bool
True  && True   = True
True  && False  = False
False && True   = False
False && False  = False

//or can define by
True && True  = True
_    && _     = False

// or
True  && b  = b
False && _  = False
```

`_` is wildcard pattern that matches any argument type

Pattern also matches in order **top to bottom, left to right**

#### List Patterns

Actually list is
```Haskell
[1,2,3,4] is 1:(2:(3:(4:[])))
```
so
```Haskell
head      :: [a] -> [a]
head (x:_) = x

tail      :: [a] -> [a]
tail (_:xs) = xs
```

`x:xs` pattern only match non-empty list

```Haskell
> head []
Error
```

`x:xs` pattern must be **parenthesis** because application have priority over `(:)`.

```Haskell
head x:_ = x
//will cause error
```
