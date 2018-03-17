# Exercise

```Haskell
Correct implementation of
halve :: [a] -> ([a], [a])

are

halve xs = splitAt (length xs `div` 2) xs
halve xs = (take (n `div` 2) xs, drop (n `div` 2) xs)
            where n = length xs
halve xs = splitAt (div (length xs) 2) xs
halve xs = (take n xs, drop n xs)
            where n = length xs `div` 2
```

```Haskell
Correct implementation of
safetail :: [a] -> [a]
which can tail empty list

safetail xs = if null xs then [] else tail xs

safetail [] = []
safetail (_:xs) = xs

safetail xs | null xs = []
            | otherwise = tail xs

safetail [] = []
safetail xs = tail xs

safetail
  = \ xs ->
      case xs of
        [] -> []
        (_ : xs) -> xs
```

```Haskell
Correct implementation of || (OR)

False || False  = False
_     || _      = True

False || b      = b
True  || _      = True

b     || c  | b == c = b
            | otherwise = True

b     || False  = b
_     || True   = True

b     || c  | b == c = c
            | otherwise = True

False || False  = False
False || True   = True
True  || False  = True  
True  || True   = True
```


```Haskell
Correct implementation of && (AND)

True  && True = True
_     && _    = False

a     && b    = if a then if b then True else False else False

a     && b    = if a then b else False

a     && b    = if b then a else False
```

```Haskell
Lambda expression of
mult x y z = x * y * z

mult = \ x -> (\ y (\ z -> x * y * z))
```

```
f x g y means
> ((f x) g) y
```

```
The type signature f :: (a -> a) -> a indicates that the function f:
> Takes a function as its argument
```

```Haskell
Choose the correct implementation for the function remove :: Int -> [a] -> [a] which takes a number n and a list and removes the element at position n from the list.

remove n xs = take n xs ++ drop (n+1) xs
```

```Haskell
What is the output of the function call
`funct 3 [1, 2, 3, 4, 5, 6, 7]`
The function funct is defined as:
funct :: Int -> [a] -> [a]
funct x xs = take (x + 1) xs ++ drop x xs

> [1,2,3,4,4,5,6,7]
```
