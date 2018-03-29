# Chapter 6: Higher-Order Functions

## Part 2

### The Foldr Function (fold right)
A number of functions on lists can be defined using the following simple pattern of recursion:
```Haskell
f []      = v
f (x:xs)  = x (+) f xs
```
`f` maps the empty list to some value v, and any non-empty list to some function `(+)` applied to its head and f of its tail

##### Example
```Haskell
sum []          = 0                 // v = 0
sum (x:xs)      = x + sum xs        // (+) = +

product []      = 1                 // v = 1
product (x:xs)  = x * product xs    // (+) = *

and []          = True              // v = True
and (x:xs)      = x && and xs       // (+) = &&
```

The higher-order library function `foldr` encapsulates this simple pattern of recursion, with the function `(+)` and the value `v` arguments

##### Example
```Haskell
sum     = foldr (+) 0

product = foldr (*) 1

or      = foldr (||) False

and     = foldr (&&) True
```

`Foldr` itself can be defined using recursion
```Haskell
//       (f == (+))     (v)
foldr ∷ (a → b → b) → b → [a] → b
foldr f v []      = v
foldr f v (x:xs)  = f x (foldr f v xs)
```

##### Example
```Haskell
sum [1,2,3]
=
foldr (+) 0 [1,2,3]
=
foldr (+) 0 (1:(2:(3:[])))
// replace : by (+)
// replace [] by 0
=
1+(2+(3+0))
=
6
```

```Haskell
product [1,2,3]
=
foldr (*) 1 [1,2,3]
=
foldr (*) 1 (1:(2:3:[]))
// replace : by (*)
// replace [] by 1
=
1*(2*(3*1))
=
6
```

```Haskell
length        ∷ [a] → Int
length        = 0
length (_:xs) = 1 + length xs

length = foldr (\_ n → 1+n) 0

// example
length [1,2,3]
=
length (1:(2:(3:[])))
// replace : by \_ n → 1+n
// replace [] by 0
=
1+(1+(1+0))
=
3
```

```Haskell
reverse []      = []
reverse (x:xs)  = reverse xs ++ [x]

reverse = foldr (\x xs → xs ++ [x]) []
(++ ys) = folder (:) ys

// example
reverse [1,2,3]
=
reverse (1:(2:(3:[])))
// replace : with \x xs → xs ++ [x]
// replace [] by []
=
(([] ++ [3]) ++ [2]) ++ [1]
=
[3,2,1]
```

### Benefits
Some recursive functions on lists, such as sum, are *simpler* to define using foldr

Properties of functions defined using foldr can be proved using algebraic properties of foldr, such as *fusion* and the *banana split* rule

Advanced program *optimizations* can be simpler if foldr is used in place of explicit recursion
