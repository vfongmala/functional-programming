# Chapter 6: Exercise

#### Exercise 0

Choose the equivalent of the following list comprehension `[f x | x <- xs, p x]` expressed using higher-order functions.

**_Answer_**

`map f (filter p xs)`

#### Exercise 1

Choose all options that implement the Prelude function

```Haskell
all :: (a → Bool) → [a] → Bool
```

taking into account only finite, non-partial input lists with non-bottom values and where the predicate p always returns either True, or False, but not bottom.

**_Answer_**

```haskell
all p xs  = and (map p xs)

all p     = and . map p

all p     = not . any (not . p)

all p xs  = foldl (&&) True (map p xs)

all p     = foldr (&&) True . map p
```

#### Exercise 2

Choose all options that implement the Prelude function

```Haskell
any :: (a → Bool) → [a] → Bool
```

taking into account only finite, non-partial input lists with non-bottom values and where the predicate p always returns either True, or False, but not bottom.

**_Answer_**

```haskell
any p     = or . map p

any p xs  = length (filter p xs) > 0

any p     = not . null . dropWhile (not . p)

any p xs  = not (all (\ x → not (p x)) xs)

any p xs  = foldr (\ x acc → (p x) || acc) False xs
```

#### Exercise 3

Choose the option that implements the Prelude function

```Haskell
takeWhile :: (a → Bool) → [a] → [a]
```

taking into account only finite, non-partial input lists with non-bottom values and where the predicate p always returns either True, or False, but not bottom.

**_Answer_**

```Haskell
takeWhile _ []  = []
takeWhile p (x : xs)
  | p x       = x : takeWhile p xs
  | otherwise = []
```

#### Exercise 4

Choose the option that implements the Prelude function

```Haskell
dropWhile :: (a → Bool) → [a] → [a]
```

taking into account only finite, non-partial input lists with non-bottom values and where the predicate p always returns either True, or False, but not bottom.

**_Answer_**

```Haskell
dropWhile p []  = []
dropWhile p (x:xs)
  | p x       = dropWhile p xs
  | otherwise = x:xs
```

#### Exercise 5

Choose the option that implements the Prelude function

```Haskell
map ∷ (a → b) → [a] → [b]
```

taking into account only finite, non-partial input lists with non-bottom values and where the mapping function does not return bottom.

**_Answer_**

```Haskell
map f = foldl (\ xs x → xs ++ [f x]) []
```

#### Exercise 6

Choose the option that implements the Prelude function

```Haskell
filter ∷ (a → Bool) → [a] → [a]
```

taking into account only finite, non-partial input lists with non-bottom values and where the predicate p always returns either True, or False, but not bottom.

**_Answer_**

```Haskell
filter p = foldr (\ x xs → if p x then x : xs else xs) []
```

#### Exercise 7
Choose a definition for the function `dec2int :: [Integer] -> Integer` that converts a finite, non-partial list of non-bottom Integer digits, that represents a decimal number, into the non-bottom Integer this list represents. For example:
```Haskell
> dec2int [2, 3, 4, 5]
2345
> dec2int []
0
> dec2int [0, 0, 0, 0]
0
```

**_Answer_**
```Haskell
dec2int = foldl (\ x y → 10 * x + y) 0
```

#### Exercise 8
Choose an explanation for why the following definition of sumsqreven is invalid:
```Haskell
sumsqreven = compose [sum, map (^ 2), filter even]

compose ∷ [a → a] → (a → a)
compose = foldr (.) id
```

**_Answer_**
```
The definition of sumsqreven doesn't event typecheck
```

#### Exercise 9
Choose the correct definition for the Prelude function `curry :: ((a, b) -> c) -> a -> b -> c` , that converts a function that takes its arguments as a pair into a function that takes its arguments one at a time. For this exercise assume that bottom does not exist.

**_Answer_**
```Haskell
curry f = \ x y → f (x, y)
```

#### Exercise 10
Choose the definition for the Prelude function `uncurry :: (a -> b -> c) -> (a, b) -> c`, that converts a function that takes its arguments one at a time into a function that takes its arguments as a pair. For this exercise assume that bottom does not exist.

**_Answer_**
```Haskell
uncurry f = \ (x, y) → f x y
```

#### Exercise 11
Consider the following higher-order function `unfold :: (b -> Bool) -> (b -> a) -> (b -> b) -> b -> [a]` that encapsulates a simple pattern of recursion for producing a list.

```Haskell
unfold p h t x
  | p x       = []
  | otherwise = h x : unfold p h t (t x)
```
The function `unfold p h t x` produces the empty list if the predicate `p x` is True. Otherwise it produces a non-empty list by applying the function `h x` to give the head of the generated list, and the function `t x` to generate another seed that is recursively processed by unfold to produce the tail of the generated list.

For example, the function `int2bin`, that converts a non-negative integer into a binary number, **with the least significant bit first**, can be defined as:

For example:
```Haskell
type Bit = Int

int2bin ∷ Int → [Bit]
int2bin 0 = []
int2bin n = n `mod` 2 : int2bin (n `div` 2)
```
This function can be rewritten more compactly using `unfold` as follows:
```Haskell
int2bin = unfold (== 0) (`mod` 2) (`div` 2)
```
Next consider the function `chop8 :: [Bit] -> [[Bit]]` that takes a list of bits and chops it into lists of at most eight bits (assuming the list is finite, non-partial, and does not contain bottom):
```Haskell
chop8 ∷ [Bit] → [[Bit]]
chop8 [] = []
chop8 bits = take 8 bits : chop8 (drop 8 bits)
```
Choose an implementation of `chop8` using `unfold`.

**_Answer_**
```Haskell
chop8 = unfold null (take 8) (drop 8)
```
