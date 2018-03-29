# Chapter 6: Higher-Order Functions

## Part 3

### Other Library Functions
The library function `(.)` returns the *composition* of two function as a single function.

```Haskell
(.)   ∷ (b → c) → (a → b) → (a → c)
f . g = \x → f (g x)
// apply (g x) first

// example
odd ∷ Int → Bool
odd = not . even
```

The library function `all` decides if every element of a list satisfies a given predicate.
```Haskell
all       ∷ (a → Bool) → [a] → Bool
all p xs  = and [p x | x ← xs]

// example
> all even [2,4,6,8,10]
True
```

The library function `any` decides if at least one element of a list satisfies a predicate
```Haskell
any       ∷ (a → Bool) → [a] → Bool
any p xs  = or [p x | x ← xs]

// example
> any isSpace "abc def"
True
```

The library function `takeWhile` selects elements from a list while a predicate holds of all the elements.
```Haskell
takeWhile       ∷ (a → Bool) → [a] → [a]
takeWhile p []  = []
takeWhile p (x:xs)
  | p x       = x : takeWhile p xs
  | otherwise = []

// example
> takeWhile isAlpha "abc def"
"abc"
```

The library function `dropWhile` removes elements while a predicate holds of all the elements.
```Haskell
dropWhile       ∷ (a → Bool) → [a] → [a]
dropWhile p []  = []
dropWhile p (x:xs)
  | p x       = dropWhile p xs
  | otherwise = x:xs

// example
> dropWhile isSpace "    abc"
"abc"
```
