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
