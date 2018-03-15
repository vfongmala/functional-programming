# Exercise

```Haskell
['a', 'b', 'c']
> [Char]

('a', 'b', 'c')
> (Char, Char, Char)

[(False , '0'), (True , '1')]
> [(Bool, Char)]

([False, True], ['0', '1'])
> ([Bool], [Char])

[tail, init, reverse]
> [[a] -> [a]]

second xs = head (tail xs)
> [a] -> a

swap (x, y) = (y, x)
> (a, b) -> (b, a)

pair x y = (x, y)
> a -> b -> (a, b)

double x = x * 2
> Num a => a -> a

palindrome xs = reverse xs == xs
> Eq a => [a] -> Bool

twice f x = f (f x)
> (a -> a) -> a -> a

Is it feasible for function types (in general) to be instances of the Eq class?
Hint: Two functions of the same type are equal iff they always return equal results for equal arguments.
> Infeasible in general; only feasible for some functions

Which of the following is not a valid list in Haskell:
> ['1',['2','3']]
> [1,[2,3],4]

["False", "True"]
> [String]

([False, True], False)
> ([Bool], Bool)

("1,2","3,4")
> (String, String)

[(1,True),(0,False)]
> [(Int, Bool)]

f xs = take 3 (reverse xs)
> [a] -> [a]

a -> b -> c -> d
> a -> (b -> (c -> d))

Which of the following expressions contains a type error:
> [1, 2, 3] ++ 4
```
